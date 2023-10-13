﻿using MarceloAnimeList.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MarceloAnimeList.Infra._4._1_Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name);

            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.Active);

            builder.HasMany(x => x.Ratings)
                .WithOne();
            builder.HasMany(x => x.UserAnimes)
                .WithOne();
        }
    }
}