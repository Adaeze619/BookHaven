using System.ComponentModel.DataAnnotations;

namespace BookHaven.UI.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
