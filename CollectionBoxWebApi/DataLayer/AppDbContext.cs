using CollectionBoxWebApi.DataLayer.Authentication;
using CollectionBoxWebApi.DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollectionBoxWebApi.DataLayer
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<CollectionGallery> Collections { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Alcohol> Alcohol { get; set; }

        public DbSet<Stamp> Stamps { get; set; }

        public DbSet<BookTag> BookTags { get; set; }

        public DbSet<AlcoholTag> AlcoholTags { get; set; }

        public DbSet<StampTag> StampTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Project>(entity =>
            //{
            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});
            base.OnModelCreating(builder);
        }
    }
}
