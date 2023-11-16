using BookHaven.Domain.Model;
using BookHaven.Domain.RequestDTO;
using BookHaven.Infrastructure.Interface;
using BookHaven.UI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookHaven.UI.Controllers
{
	public class BooksController : Controller
	{

		private readonly IBookHavenRepo _bookHavenRepo;
		private readonly ITagRepository _tagRepository;
		private readonly ILogger<BooksController> _logger;

		public BooksController(IBookHavenRepo bookHavenRepo, ITagRepository tagRepository, ILogger<BooksController> logger)
		{
			_bookHavenRepo = bookHavenRepo;
			_tagRepository = tagRepository;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			// get tags from repository
			var tags = await _tagRepository.GetAllAsync();

			var model = new AddBookPostRequest 
			{
				Tags = tags.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
			};

			return View(model);

		}

		[HttpPost]
		public async Task<IActionResult> Add(AddBookPostRequest addBookRequestDTO)
		{
			// Map view model to domain model

			var book = new Book
			{
				BookTitle = addBookRequestDTO.BookTitle,
				Description = addBookRequestDTO.Description,
				ImageUrlHandle = addBookRequestDTO.ImageUrlHandle,
				ISBN = addBookRequestDTO.ISBN,
				PublishedDate = addBookRequestDTO.PublishedDate,
				Author = addBookRequestDTO.Author,
				Visible = addBookRequestDTO.Visible,
				//dunno how to map relations with Tag

			};


			// Map Tags from selected tags
			var selectedTags = new List<BookHavenTag>();
			foreach (var selectedTadId in addBookRequestDTO.SelectedTags)
			{
				var selectedTadIdAsGuid = Guid.Parse(selectedTadId);
				var existingTag = await _tagRepository.GetAsync(selectedTadIdAsGuid);

				if (existingTag != null)
				{
					selectedTags.Add(existingTag);
				}
			}

			// Mapping tags back to domain model
			book.Tags = selectedTags;

			await _bookHavenRepo.AddAsync(book);

			return RedirectToAction("Add");
		}

		
		[HttpGet]
		[ActionName("List")]
		public async Task<IActionResult> List()
		{
			var getallbook = await _bookHavenRepo.GetAllAsync();

			return View(getallbook);
		}

		//public async Task<IActionResult> Details(Guid isbn)
		//{
		//	var book = await _bookHavenRepo.GetAsync(isbn);
		//	return View(book);
		//}
		[HttpPut]
		public async Task<IActionResult> Update(string ISBN, [FromBody] UpdateBookRequest updateBookRequest)
		{
			var book = new Book
			{
				BookTitle = updateBookRequest.BookTitle,
				Description = updateBookRequest.Description,
				ISBN = updateBookRequest.ISBN,
				Author = updateBookRequest.Author,
			};

			var editedBook = await _bookHavenRepo.UpdateAsync(book);

			if (editedBook == null)
			{
				// Log the error
				_logger.LogError("Failed to update book with ISBN: {ISBN}", updateBookRequest.ISBN);

				// Return an error view or message
				//  return View("Error"); // You should create an "Error" view
				return NotFound("Book not found");
			}

			// Redirect to a success page or show a success message
			return RedirectToAction("UpdateSuccess", new { ISBN = updateBookRequest.ISBN });
		}


		[HttpDelete]
		[Route("{Id:Guid}")]
		public async Task<IActionResult> Delete([FromRoute] Guid Id)
		{
			var Tobedeleted = await _bookHavenRepo.DeleteAsync(Id);
			if (Tobedeleted)
			{
				return RedirectToAction("List");
			}

			// If the item was not found or not deleted, redirect to "ErrorAction"
			return RedirectToAction("ErrorAction", new { message = "Item not found or could not be deleted" });
		}



		public IActionResult Search()
		{
			return View();
		}



		[HttpPost]
		public async Task<IActionResult> Search(string searchQuery)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var book = await _bookHavenRepo.SearchBooksAsync(searchQuery);
					return View(book);
				}
				catch (ApplicationException ex)
				{
					ViewBag.ErrorMessage = ex.Message;
				}
			}
			else
			{
				ViewBag.ErrorMessage = "Please check the provided search term.";
			}

			return View();
		}


	}
}
