
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FrontEnd.Controllers
{
    public class CursusUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(ICollection<IFormFile> files)
        {
            List<Cursus> cursussen = new List<Cursus>();
            CursusParser parser = new CursusParser();

            foreach (IFormFile file in files)
            {
                IEnumerable<Cursus> foundCursussen = ParseFile(file);

                cursussen.AddRange(foundCursussen);
            }

            return View();
        }

        private IEnumerable<Cursus> ParseFile(IFormFile file)
        {
            using(Stream stream = file.OpenReadStream())
            {
                int offset = 0;
                byte[] buffer = new byte[file.Length];

                int lines = stream.Read(buffer, offset, 4);
            }
        }
    }
}
