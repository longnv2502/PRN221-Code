using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using RazorPagesLabA1.Models;

namespace RazorPagesLabA1.Pages
{
    public class CustomerFormModel : PageModel
    {
        public void OnGet()
        {
        }
        public string Message { set; get; }
        [BindProperty]
        public Customer customerInfo { set; get; }

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
