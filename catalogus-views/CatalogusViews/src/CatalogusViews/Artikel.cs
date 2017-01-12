namespace CatalogusViews.Controllers
{
    public class Artikel
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public string FotoUrl { get; set; }

        public Artikel(int id, string naam, decimal prijs, string fotoUrl)
        {
            ID = id;
            Naam = naam;
            Prijs = prijs;
            FotoUrl = fotoUrl;
        }
    }
}