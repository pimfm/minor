using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RepositoryDemo.Entities;
using RepositoryDemo.Infrastructure.DataAccessLayer;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace RepositoryDemo.Repositories
{
    public class ProductRepository : BaseRepository<Products, int>
    {
        public override Products Find(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return ProductsIncludingCategories(context).Where(p => p.ProductId == id).FirstOrDefault();
            }
        }

        public override IEnumerable<Products> FindAll()
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                return ProductsIncludingCategories(context).ToList();
            }
        }

        public override IEnumerable<Products> FindBy(Expression<Func<Products, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return ProductsIncludingCategories(context).Where(filter).ToList();
            }
        }

        private static IIncludableQueryable<Products, Categories> ProductsIncludingCategories(NorthwindContext context)
        {
            return context.Products.Include(p => p.Category);
        }

        public override DbSet<Products> ProvideDatabaseSet()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products; 
            }
        }
    }
}
