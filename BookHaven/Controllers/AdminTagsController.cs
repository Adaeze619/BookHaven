﻿
using BookHaven.Domain.Model;
using BookHaven.Infrastructure.Interface;
using BookHaven.UI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookHaven.UI.Controllers
{
	public class AdminTagsController : Controller
	{
			private readonly ITagRepository _tagRepository;

			public AdminTagsController(ITagRepository tagRepository)
			{
				_tagRepository = tagRepository;
			}


			[HttpGet]
			public IActionResult Add()
			{
				return View();
			}

			[HttpPost]
			[ActionName("Add")]
			public async Task<IActionResult> Add(AddTagRequest addTagRequest)
			{
				ValidateAddTagRequest(addTagRequest);

				if (ModelState.IsValid == false)
				{
					return View();
				}

				// Mapping AddTagRequest to Tag domain model
				var tag = new BookHavenTag
				{
					Name = addTagRequest.Name,
					DisplayName = addTagRequest.DisplayName
				};

				await _tagRepository.AddAsync(tag);

				return RedirectToAction("List");
			}

			[HttpGet]
			[AcceptVerbs("List")]
			public async Task<IActionResult> List()
			{
				// use dbcontext to read the tag
				var tags = await _tagRepository.GetAllAsync();

				return View(tags);
			}

			[HttpGet]
			public async Task<IActionResult> Edit(Guid id)
			{
				var tag = await _tagRepository.GetAsync(id);

				if (tag != null)
				{
					var editTagRequest = new EditTagRequest
					{
						Id = tag.Id,
						Name = tag.Name,
						DisplayName = tag.DisplayName
					};

					return View(editTagRequest);
				}

				return View(null);
			}

			[HttpPost]
			public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
			{
				var tag = new BookHavenTag
				{
					Id = editTagRequest.Id,
					Name = editTagRequest.Name,
					DisplayName = editTagRequest.DisplayName
				};


				var updatedTag = await _tagRepository.UpdateAsync(tag);

				if (updatedTag != null)
				{
					// Show success notification
					return RedirectToAction("List");
				}
				//else
				//{
				//	// Show error notification
				//}

				return RedirectToAction("Edit", new { id = editTagRequest.Id });
			}

			[HttpPost]
			public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
			{
				var deletedTag = await _tagRepository.DeleteAsync(editTagRequest.Id);
				if (deletedTag != null)
				{
					return RedirectToAction("List");
				}

				//Show an error notification
				return RedirectToAction("Edit", new { id = editTagRequest.Id });
			}

			private void ValidateAddTagRequest(AddTagRequest request)
			{
				if (request.Name is not null && request.DisplayName is not null)
				{
					if (request.Name == request.DisplayName)
					{
						ModelState.AddModelError("DisplayName", "Name cannot be the same as DisplayName");
					}
				}
			}
		}
	}

