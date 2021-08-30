using CollectionBoxWebApi.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollectionBoxWebApi.DataLayer.Helpers
{
    public class DataDbContext : DbContext
    {  
        public DbSet<CollectionGallery> Collections { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Alcohol> Alcohol { get; set; }

        public DbSet<Stamp> Stamps { get; set; }

        public DbSet<BookTag> BookTags { get; set; }

        public DbSet<AlcoholTag> AlcoholTags { get; set; }

        public DbSet<StampTag> StampTags { get; set; }

        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

    }
}
