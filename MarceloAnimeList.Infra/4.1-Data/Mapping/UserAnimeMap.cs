using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MarceloAnimeList.Domain.Data.Entity;

namespace MarceloAnimeList.Infra._4._1_Data.Mapping
{
    public class UserAnimeMap : IEntityTypeConfiguration<UserAnime>
    {
        public void Configure(EntityTypeBuilder<UserAnime> builder)
        {
            builder.ToTable("UserAnime");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status);
            builder.Property(x => x.Episode);
            builder.Property(x => x.Season);

            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.Active);

            builder.HasMany(x => x.Anime)
                .WithOne();
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
