using System.ComponentModel.DataAnnotations;

namespace BookHaven.Domain.Model
{
    public class AddTagRequest
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string DisplayName { get; set; }
    }
}
