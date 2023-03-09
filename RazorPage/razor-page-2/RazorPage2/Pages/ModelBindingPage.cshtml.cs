using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web.Helpers;
using System.Xml.Linq;

namespace RazorPage2.Pages
{
    public class ModelBindingPageModel : PageModel
    {
        public void OnPost(string Username, string Email)
        {
            ViewData["Confimrmation"] = $"{Username} will be sent to email: {Email}";
        }
    }

}
