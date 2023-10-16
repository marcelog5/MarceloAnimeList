using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MarceloAnimeList.Domain.Data.Entity;

namespace MarceloAnimeList.Infra._4._1_Data.Mapping
{
    public class AnimeMap : IEntityTypeConfiguration<Anime>
    {
        public void Configure(EntityTypeBuilder<Anime> builder)
        {
            builder.ToTable("Anime");

            builder.Property(x => x.EpisodeCount);
            builder.Property(x => x.Season);
            builder.Property(x => x.Type);
        }
    }
}
