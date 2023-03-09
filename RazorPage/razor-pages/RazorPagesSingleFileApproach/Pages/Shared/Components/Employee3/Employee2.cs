using Microsoft.AspNetCore.Mvc;

namespace RazorPagesSingleFileApproach.Pages.Shared.Components.Student
{
    public class Employee2 : ViewComponent
    {
        public string Invoke()
        {
            return "Name with View Component";
        }
    }
}
