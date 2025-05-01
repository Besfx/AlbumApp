using AlbumApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumApp.Entities
{
    public class AlbumsDbContext : DbContext
    {
        public AlbumsDbContext(DbContextOptions<AlbumsDbContext> options)
            : base(options)
        {
        }

        // Add your properties for accessing your entities here..

       public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().HasData(
                new Album { Id = 1, Title = "Morayo", Artist = "Wizkid", Rating = 8.0m, Song = "kese" },
                new Album { Id = 2, Title = "Timeless", Artist = "Davido", Rating = 9.0m, Song = "Overdem" }
            );
        }
    }
}
