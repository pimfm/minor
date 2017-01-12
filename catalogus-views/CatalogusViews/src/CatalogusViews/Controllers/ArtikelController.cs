using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CatalogusViews.Controllers
{
    public class ArtikelController : Controller
    {
        public IActionResult Details(int id)
        {
            Artikel artikel = new Artikel(1, "Fietslamp", 5.00m, "superlight_red_small.gif");
            IEnumerable<Artikel> gerelateerdeArtikellen = new List<Artikel>()
            {
                new Artikel(2, "Fietswiel", 2.00M, "wheel_small.gif"),
                new Artikel(3, "Rood zadel", 13.00M, "saddle_small.gif"),
                new Artikel(4, "Fietslamp", 5.00m, "superlight_red_small.gif")
            };
            ArtikelBekijkenViewModel model = new ArtikelBekijkenViewModel(artikel, gerelateerdeArtikellen);

            return View(model);
        }
    }
}
