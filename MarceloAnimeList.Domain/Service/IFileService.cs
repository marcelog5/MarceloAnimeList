﻿using MarceloAnimeList.Domain.Data.Entity;

namespace MarceloAnimeList.Domain.Service
{
    public interface IFileService
    {
        List<Media> Parser(string content);
    }
}
