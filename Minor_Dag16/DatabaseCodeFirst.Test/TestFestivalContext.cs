using DatabaseCodeFirst.Infrastructure.DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseCodeFirst.Test
{
    [TestClass]
    public class TestFestivalContext
    {
        [TestMethod]
        public void TestContextCanBeUsed()
        {
            using (FestivalContext database = new FestivalContext())
            {
                Assert.AreEqual("something", database.Database.ToString());
            }
        }
    }
}
