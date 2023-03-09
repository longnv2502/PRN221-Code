using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesLabA1.Pages
{
    public class UploadFilesModel : PageModel
    {
        private IHostEnvironment _environment;
        public UploadFilesModel(IHostEnvironment environment)
        {
            _environment = environment;
        }

        [Required(ErrorMessage = "Please choose at least one file.")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Choose File(s) to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }
        public async Task OnPostAsync()
        {
            if (FileUploads != null)
            {
                foreach (var FileUpload in FileUploads)
                {
                    var file = Path.Combine(_environment.ContentRootPath, "Images",
                    FileUpload.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))

                        await FileUpload.CopyToAsync(fileStream);
                }
            }
        }

    }
}