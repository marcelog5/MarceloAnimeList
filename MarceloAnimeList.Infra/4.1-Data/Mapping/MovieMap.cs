using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MarceloAnimeList.Domain.Data.Entity;

namespace MarceloAnimeList.Infra._4._1_Data.Mapping
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");

            builder.Property(x => x.Duration);
        }
    }
}
