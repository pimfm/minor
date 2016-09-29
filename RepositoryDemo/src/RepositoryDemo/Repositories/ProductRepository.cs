using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RepositoryDemo.Entities;
using RepositoryDemo.Infrastructure.DataAccessLayer;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RepositoryDemo.Repositories
{
    public class ProductRepository : BaseRepository<Products, int>
    {
        public override Products Find(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products
                                .Where(p => p.ProductId == id)
                                .Include(p => p.Category)
                                .FirstOrDefault();
            }
        }

        public override IEnumerable<Products> FindAll()
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }

        public override IEnumerable<Products> FindBy(Expression<Func<Products, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.Where(filter).ToList();
            }
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
