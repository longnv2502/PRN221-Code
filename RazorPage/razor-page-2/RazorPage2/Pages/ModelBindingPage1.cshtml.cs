using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage2.Pages
{
    public class ModelBindingPage1Model : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty(Name = "username")]
        public string Name { set; get; }
        public void OnPost()
        {
            ViewData["Confimrmation"] = $"{Name} will be sent to email: {Email}";
        }
    }
}
