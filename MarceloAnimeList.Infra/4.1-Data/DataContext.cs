using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Infra._4._1_Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MarceloAnimeList.Infra._4._1_Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>(new MediaMap().Configure);
            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Anime>(new AnimeMap().Configure);
            modelBuilder.Entity<Manga>(new MangaMap().Configure);
            modelBuilder.Entity<Movie>(new MovieMap().Configure);
            modelBuilder.Entity<Rating>(new RatingMap().Configure);
            modelBuilder.Entity<UserAnime>(new UserAnimeMap().Configure);
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
