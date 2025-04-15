using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
using Microsoft.EntityFrameworkCore;

namespace Test_Layer
{
    internal class TestManager
    {
        internal static WebsiteDbContext dbContext { get; set; }
        static TestManager()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseInMemoryDatabase("InMemoryDb");
            dbContext=new WebsiteDbContext(dbContextOptionsBuilder.Options);

        }
        [OneTimeTearDown]
        public void Dipose()
        {
            dbContext.Dispose();
        }
    }
}
