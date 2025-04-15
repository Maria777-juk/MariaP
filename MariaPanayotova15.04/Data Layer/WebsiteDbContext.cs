using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Layer;

namespace Data_Layer
{
    public class WebsiteDbContext : DbContext
    {

        public WebsiteDbContext() : base()
        {

        }

        public WebsiteDbContext(DbContextOptions options)
        : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            base.OnConfiguring(optionsBuilder.UseSqlite("Data source=Maria.db3"));

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Hobby> Hobbies { get; set; }

        public DbSet<District> Districts { get; set; }



    }




}

