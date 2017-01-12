using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestitOut.DAL.Repositories;
using TestitOut.Entities;

namespace TestitOut.Infrastructure.Test
{
    [TestClass]
    public class DALTest
    {
        private DbContextOptions _options;
        private static DbContextOptions<ExampleContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<ExampleContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [TestInitialize]
        public void Init()
        {
            _options = CreateNewContextOptions();
        }

        [TestMethod]
        public void TestAdd()
        {
            using (var repo = new ExampleRepository(new ExampleContext(_options)))
            {
                repo.Insert(new Example()
                {
                    Name = "Naam"
                });
            }

            using (var repo = new ExampleRepository(new ExampleContext(_options)))
            {
                Assert.AreEqual(1, repo.FindAll().Count());
                Assert.AreEqual("Naam", repo.Find(1).Name);
            }
        }

        [TestMethod]
        public void TestFind()
        {
            using (var repo = new ExampleRepository(new ExampleContext(_options)))
            {
                repo.Insert(new Example()
                {
                    Name = "Name"
                });
            }

            using (var repo = new ExampleRepository(new ExampleContext(_options)))
            {
                var result = repo.Find(1);
                Assert.AreEqual(1, result.Id);
                Assert.AreEqual("Name", result.Name);
            }
        }
        [TestMethod]
        public void TestDelete()
        {
            using (var repo = new ExampleRepository(new ExampleContext(_options)))
            {
                var example = new Example()
                {
                    Name = "Name"
                };
                repo.Insert(example);
                repo.Delete(1);
            }

            using (var repo = new ExampleRepository(new ExampleContext(_options)))
            {
                Assert.AreEqual(0, repo.FindAll().Count());
            }
        }
        [TestMethod]
        public void TestFindAll()
        {
            using (var repo = new ExampleRepository(new ExampleContext(_options)))
            {
                var example = new Example()
                {
                    Name = "Example"
                };
                repo.Insert(example);
                example = new Example()
                {
                    Name = "Name"
                };
                repo.Insert(example);
            }

            using (var repo = new ExampleRepository(new ExampleContext(_options)))
            {
                Assert.AreEqual(2, repo.FindAll().Count());
            }
        }

        [TestMethod]
        public void TestUpdate()
        {

            using (var repo = new ExampleRepository(new ExampleContext(_options)))
            {
                repo.Insert(new Example()
                {
                    Name = "Naam"
                });
            }

            using (var repo = new ExampleRepository(new ExampleContext(_options)))
            {
                repo.Update(new Example()
                {
                    Id = 1,
                    Name = "Aangepast"
                });
            }


            using (var repo = new ExampleRepository(new ExampleContext(_options)))
            {
                Assert.AreEqual(1, repo.FindAll().Count());
                Assert.AreEqual("Aangepast", repo.Find(1).Name);
            }
        }
    }
}
