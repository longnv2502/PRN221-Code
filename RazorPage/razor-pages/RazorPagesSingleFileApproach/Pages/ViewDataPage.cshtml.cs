using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace RazorPagesSingleFileApproach.Pages
{
    public class ViewDataPageModel : PageModel
    {
        [ViewData]
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "View Data Test";
            IList<Student> studentList = new List<Student>();
            studentList.Add(new Student() { StudentName = "Bill" });
            studentList.Add(new Student() { StudentName = "Steve" });
            studentList.Add(new Student() { StudentName = "Ram" });
            ViewData["students"] = studentList;
        }
    }
}
