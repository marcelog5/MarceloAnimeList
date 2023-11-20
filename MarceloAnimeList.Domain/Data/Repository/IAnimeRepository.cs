﻿using CarRare.Commom.DomainLayer.Data;
using MarceloAnimeList.Domain.Data.Entity;

namespace MarceloAnimeList.Domain.Data.Repository
{
    public interface IAnimeRepository : IRepository<Anime, Guid>
    {
    }
}
