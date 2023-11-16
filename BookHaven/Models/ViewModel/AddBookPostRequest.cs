using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookHaven.UI.Models.ViewModel
{
	public class AddBookPostRequest
	{
		public string BookTitle { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string ImageUrlHandle { get; set; } = string.Empty;
		public string ISBN { get; set; } = string.Empty;
		public DateTime PublishedDate { get; set; }
		public string Author { get; set; } = string.Empty;
		public bool Visible { get; set; }

		// Navigation Property
		// Display tags
		public IEnumerable<SelectListItem> Tags { get; set; }
		// Collect Tag
		public string[] SelectedTags { get; set; } = Array.Empty<string>();

	}
}
