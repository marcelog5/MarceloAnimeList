﻿using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Service.Command.FileParse;
using MarceloAnimeList.Service.Command.FileParse.AnimeParse;
using System.Text.RegularExpressions;

namespace MarceloAnimeList.Service.Service
{
    public class FileService : IFileService
    {
        public List<Media> Parser(string content)
        {
            var animes = ParseAnimeText(content);
            return new List<Media>();
        }

        public static List<Anime> ParseAnimeText(string inputText)
        {
            List<Anime> animes = new List<Anime>();

            // Define regular expressions to match anime entries
            string pausedAnimePattern = @"--animes em pausa--(.*?)--Animes assistidos--";
            string watchedAnimePattern = @"--Animes assistidos--(.*?)-- filme de anime assistidos --";
            string possibleAnimePattern = @"-- animes possiveis --";

            // Match paused and watched anime sections
            Match pausedAnimeMatch = Regex.Match(inputText, pausedAnimePattern, RegexOptions.Singleline);
            Match watchedAnimeMatch = Regex.Match(inputText, watchedAnimePattern, RegexOptions.Singleline);
            Match possibleAnimeMatch = Regex.Match(inputText, possibleAnimePattern, RegexOptions.Singleline);

            if (pausedAnimeMatch.Success)
            {
                // Parse paused anime entries
                string pausedAnimeText = pausedAnimeMatch.Groups[1].Value;

                IMediaParser<Anime> pausedAnimeParser = new PausedAnimeParser();
                var pausedAnimes = pausedAnimeParser.HandleParser(pausedAnimeText);
                
                animes.AddRange(pausedAnimes);
            }

            if (watchedAnimeMatch.Success)
            {
                // Parse paused anime entries
                string watchedAnimeText = watchedAnimeMatch.Groups[1].Value;

                IMediaParser<Anime> watchedAnimeParser = new WatchedAnimeParser();
                var watchedAnimes = watchedAnimeParser.HandleParser(watchedAnimeText);

                animes.AddRange(watchedAnimes);
            }

            if (possibleAnimeMatch.Success)
            {
                // Parse paused anime entries
                string possibleAnimeText = possibleAnimeMatch.Groups[1].Value;

                IMediaParser<Anime> possibleAnimeParser = new PossibleAnimeParser();
                var watchedAnimes = possibleAnimeParser.HandleParser(possibleAnimeText);

                animes.AddRange(watchedAnimes);
            }

            return animes;
        }
    }
}

