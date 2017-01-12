using System.Collections.Generic;

namespace CatalogusViews.Controllers
{
    public class ArtikelBekijkenViewModel
    {
        public Artikel HoofdArtikel { get; set; }
        public IEnumerable<Artikel> GerelateerdeArtikelen { get; set; }

        public ArtikelBekijkenViewModel(Artikel hoofdArtikel, IEnumerable<Artikel> gerelateerdeArtikelen)
        {
            HoofdArtikel = hoofdArtikel;
            GerelateerdeArtikelen = gerelateerdeArtikelen;
        }
    }
}