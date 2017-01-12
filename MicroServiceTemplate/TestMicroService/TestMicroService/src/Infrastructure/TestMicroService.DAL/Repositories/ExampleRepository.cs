using Microsoft.EntityFrameworkCore;

namespace TestMicroService.DAL.Repositories
{
    public class ExampleRepository
        : BaseRepository<Example, int, ExampleContext>
    {
        public ExampleRepository(ExampleContext context) : base(context)
        {
        }

        protected override DbSet<Example> GetDbSet()
        {
            return _context.Examples;
        }

        protected override int GetKeyFrom(Example item)
        {
            return item.Id;
        }
    }
}