using MarceloAnimeList.Domain.Entity;
using MarceloAnimeList.Infra._4._1_Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MarceloAnimeList.Infra._4._1_Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=;User=sa;Password=P@ssw0rd#2023;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>(new AnimeMap().Configure);
        }

        public DbSet<Media> Media { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Anime> Anime { get; set; }
        public DbSet<Manga> Manga { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<UserAnime> UserAnime { get; set; }
    }
}
