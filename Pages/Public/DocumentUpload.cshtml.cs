using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApp.Models;

namespace RazorWebApp.Pages.Public
{
    public class DocumentUploadModel : PageModel
    {
        private IWebHostEnvironment _hostingEnvironment;
        public DocumentUploadModel(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public List<Files> Files { get; set; }


        [BindProperty]
        [Required]
        [MinLength(6)]
        public string FirstName { get; set; }
        [BindProperty]
        [Required, MinLength(6)]
        public string LastName { get; set; }

        public void OnGet()
        {
            
        }

        public ActionResult OnPostUpload(List<IFormFile> files)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ModelState.IsValid)
            {
                //FirstName = form.FirstName;
                //LastName = form.LastName;
                if (files != null && files.Count > 0)
                {
                    string folderName = "Upload";
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string newPath = Path.Combine(webRootPath, folderName);
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }

                    foreach (IFormFile item in files)
                    {
                        if (item.Length > 0)
                        {
                            string fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                            string fullPath = Path.Combine(newPath, fileName);
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                item.CopyTo(stream);
                                Files myfiles = new Files();
                                myfiles.FileId = Guid.NewGuid();
                                myfiles.FileName = fileName;
                                myfiles.FileType = item.ContentType;
                                Files.Add(myfiles);
                            }
                        }
                    }
                    return Page();
                }
                
            }
            return this.Content("Fail");
        }



    }
}
