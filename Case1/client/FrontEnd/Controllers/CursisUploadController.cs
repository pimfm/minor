
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FrontEnd.Controllers
{
    public class CursisUploadController : Controller
    {
        private IHostingEnvironment _environment;

        public CursisUploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(ICollection<IFormFile> files)
        {
            foreach (IFormFile file in files)
            {
                WriteToUploadsFolder(file);
            }

            return View();
        }

        private void WriteToUploadsFolder(IFormFile file)
        {
            string filePath = ProvideAvailableFilePath(file.FileName);

            using (FileStream fileStream = System.IO.File.Create(filePath))
            {
                file.CopyTo(fileStream);
            }
        }

        private string ProvideAvailableFilePath(string fileName)
        {
            string folder = Path.Combine(_environment.WebRootPath, "uploads");

            for (int i = 0; true; i++)
            {
                string filePath = Path.Combine(folder, $"{i}_{fileName}");

                if (System.IO.File.Exists(filePath) == false)
                {
                    return filePath;
                }
            }
        }
    }
}
