using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RazorPage2.Pages
{
    public class ModelStatePageModel : PageModel
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
        public string Message { set; get; }
        public void Onpost()
        {

            if (ModelState.IsValid)
            {
                Message = "Information is OK";
                ModelState.Clear();

            }
            else
            {
                Message = "Error on input data.";
            }
        }

    }
}
