namespace WebAPIServiceLayer.Domain.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }

        public Product(string name, decimal price, string brand = null)
        {
            Name = name;
            Price = price;
            Brand = brand;
        }
    }
}