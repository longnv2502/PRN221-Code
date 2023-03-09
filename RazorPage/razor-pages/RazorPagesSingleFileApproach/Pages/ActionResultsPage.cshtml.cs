using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesSingleFileApproach.Pages
{
    public class ActionResultsPageModel : PageModel
    {
        public IActionResult OnGet()
        {
            return new RedirectToPageResult("Index");
        }
    }
}
