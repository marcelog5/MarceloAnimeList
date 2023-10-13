using MarceloAnimeList.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MarceloAnimeList.Infra._4._1_Data.Mapping
{
    public class MediaMap : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.ToTable("Media");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title);
            builder.Property(x => x.Genre);
            builder.Property(x => x.Status);
            builder.Property(x => x.ReleaseDate);

            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.Active);

            builder.HasMany(x => x.Ratings)
                .WithOne();
        }
    }
}
