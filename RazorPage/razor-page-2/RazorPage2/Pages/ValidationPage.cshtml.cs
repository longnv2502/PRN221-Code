using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RazorPage2.Pages
{
    public class ValidationPageModel : PageModel
    {
        [BindProperty]
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }
        [BindProperty]
        [Required, MinLength(6)]
        public string Password { get; set; }
        [BindProperty, Required, Compare(nameof(Password))]
        public string Password2 { get; set; }
        public void OnGet()
        {
        }
    }
}
