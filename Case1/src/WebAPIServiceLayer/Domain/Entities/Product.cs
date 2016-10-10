namespace BackendService.Domain.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }

        // Required for entity framework
        public Product()
        {
            Name = "Unknown";
        }

        public Product(string name, decimal price, string brand = null)
        {
            Name = name;
            Price = price;
            Brand = brand;
        }
    }
}