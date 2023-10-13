using MarceloAnimeList.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MarceloAnimeList.Infra._4._1_Data.Mapping
{
    public class MangaMap : IEntityTypeConfiguration<Manga>
    {
        public void Configure(EntityTypeBuilder<Manga> builder)
        {
            builder.ToTable("Manga");

            builder.Property(x => x.Chapter);
            builder.Property(x => x.Pages);
        }
    }
}
