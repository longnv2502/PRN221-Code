using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesSingleFileApproach.Pages
{
    public class PageModelFilesModel : PageModel
    {

        [BindProperty]
        public string Name { get; set; }
        public void OnGet()
        {
        }
    }
}
