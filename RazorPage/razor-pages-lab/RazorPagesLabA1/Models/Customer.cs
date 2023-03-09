using Microsoft.AspNetCore.Mvc;
using RazorPagesLabA1.Binding;
using RazorPagesLabA1.Validation;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RazorPagesLabA1.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Customer nase is requiredi!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The length of nane is from 3 to 20 charater")]
        [Display(Name = "Customer name")]
        [ModelBinder(BinderType = typeof(CheckNameBinding))]
        public string CustomerName { set; get; }
        [Required(ErrorMessage = "Customer email is requiredi!")]
        [EmailAddress]
        [Display(Name = "Customer email")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Year of birth is requiredt!")]
        [Display(Name = "Year of birth")]
        [Range(1960, 2000, ErrorMessage  = "1960 - 2000")]
        [CustomerValidation]
    public int YearOfBirth { get; set; }
    }
}
