using RepositoryDemo.Entities;
using RepositoryDemo.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RepositoryDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProductRepository repository = new ProductRepository();

            Find(repository);
            FindBy(repository);
            FindAll(repository);
        }

        private static void FindAll(ProductRepository repository)
        {
            int amountOfProducts = repository.FindAll().Count();

            Console.WriteLine($"FINDALL: {amountOfProducts}");
        }

        private static void Find(ProductRepository repository)
        {
            Products product = repository.Find(1);

            Console.WriteLine($"FIND: {product.ProductId} -> {product.ProductName}");
        }

        private static void FindBy(ProductRepository repository)
        {
            IEnumerable<Products> foundProducts = repository.FindBy(p => p.UnitsInStock > 20);

            Console.WriteLine($"FINDBY: {foundProducts.Count()}");
        }
    }
}
