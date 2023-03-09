using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage3.Pages
{
    public class AjaxPartialModel : PageModel
    {
        private ICarService _carService;
        public AjaxPartialModel(ICarService carService)
        {
            _carService = carService;
        }
        public List<Car> Cars { get; set; }
        public void OnGet(){}
        public PartialViewResult OnGetCarPartial()
        {
            Cars = _carService.GetAll();
            return Partial("_CarPartial", Cars);
        }
    }
}
