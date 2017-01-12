using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CatalogusViews.Controllers
{
    public class CatalogusController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Artikel> artikellen = new List<Artikel>()
            {
                new Artikel(1, "Fietswiel", 2.00M, "wheel_small.gif"),
                new Artikel(2, "Rood zadel", 13.00M, "saddle_small.gif"),
                new Artikel(3, "Fietslamp", 5.00m, "superlight_red_small.gif")
            };
            return View(artikellen);
        }
    }
}
