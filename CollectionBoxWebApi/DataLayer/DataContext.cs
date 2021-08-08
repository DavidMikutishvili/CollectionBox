using CollectionBoxWebApi.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.DataLayer.Helpers
{
    public class DataContext : DbContext
    {  
        //protected readonly IConfiguration
        public DbSet<User> Users { get; set; }  
        
        public DbSet<Collection> Collections { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Alcohol> Alcohol { get; set; }

        public DbSet<Stamp> Stamps { get; set; }

        public DbSet<BookTag> BookTags { get; set; }

        public DbSet<AlcoholTag> AlcoholTags { get; set; }

        public DbSet<StampTag> StampTags { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CollectionBoxDB;Trusted_Connection=True;");
        }
    }
}
