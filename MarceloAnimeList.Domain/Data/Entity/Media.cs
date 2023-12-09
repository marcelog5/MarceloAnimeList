﻿using CarRare.Common.DomainLayer.Data;
using MarceloAnimeList.Domain.Enum;

namespace MarceloAnimeList.Domain.Data.Entity
{
    public class Media : IDomainEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public EnMediaGenreType? Genre { get; set; } = EnMediaGenreType.Other;
        public EnMediaStatus? Status { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Active { get; set; } = true;
        public ICollection<Rating>? Ratings { get; set; }
    }
}
