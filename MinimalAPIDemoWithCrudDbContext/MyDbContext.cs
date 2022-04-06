using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MinimalAPIDemoWithCrudModels;

namespace MinimalAPIDemoWithCrudDbContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            :base(options)
        {

        }

        public MyDbContext()
        {

        }

        public DbSet<StoreInformation> StoreInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-J89CJKG\\SQLEXPRESS;Database=MinimalAPIDemoWithCrudDB;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MinimalAPIDemoWithCrudDB;Trusted_Connection=True;");//work
            base.OnConfiguring(optionsBuilder);
        }
    }
}
