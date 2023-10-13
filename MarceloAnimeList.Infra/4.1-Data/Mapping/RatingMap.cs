﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MarceloAnimeList.Domain.Data.Entity;

namespace MarceloAnimeList.Infra._4._1_Data.Mapping
{
    public class RatingMap : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Rating");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type);
            builder.Property(x => x.Score);
            builder.Property(x => x.Comment);

            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.Active);
        }
    }
}
