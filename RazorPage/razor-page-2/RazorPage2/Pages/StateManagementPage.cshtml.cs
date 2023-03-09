using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace RazorPage2.Pages
{
    public class StateManagementPageModel : PageModel
    {

        public void OnGet()
        {
            HttpContext.Session.SetString("Test String", "1");
            HttpContext.Session.SetInt32("Test Int", 1);
            HttpContext.Session.Set("Test Byte Array", BitConverter.GetBytes(true));
        }
        
    }
}
