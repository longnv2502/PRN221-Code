using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesSingleFileApproach.Pages
{
    public class TagHelpersPageModel : PageModel
    {
        [BindProperty]
        public Member Member { get; set; }
        public void OnGet()
        {
        }
    }
}
