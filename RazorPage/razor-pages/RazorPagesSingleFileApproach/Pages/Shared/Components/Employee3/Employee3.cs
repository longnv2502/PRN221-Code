using Microsoft.AspNetCore.Mvc;

namespace RazorPagesSingleFileApproach.Pages.Shared.Components.Student
{
    public class Employee3 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("EmployeeView");
        }
    }
}
