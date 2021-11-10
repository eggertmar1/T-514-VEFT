using Microsoft.EntityFrameworkCore;
using Datafication.Repositories.Entities;
namespace Datafication.Repositories.Contexts
{
    public class IceCreamDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // manual config of relations -> many to many
            modelBuilder.Entity<IceCreamCategory>()
                .HasNoKey(); //(x => new { x.CategoriesId, x.NewsItemsId });
            // modelBuilder.Entity<AuthorNewsItem>()
            //     .HasKey(x => new { x.AuthorsId, x.NewsItemsId });
        }
        public IceCreamDbContext(DbContextOptions<IceCreamDbContext> options) : base(options) {}
        public DbSet<Category> Categories { get; set; }
        public DbSet<IceCream> IceCreams { get; set; }
        public DbSet<IceCreamCategory> CategoryIceCream { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

    }
}