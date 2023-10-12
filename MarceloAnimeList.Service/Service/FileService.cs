using MarceloAnimeList.Domain.Entity;
using MarceloAnimeList.Domain.Enum;
using MarceloAnimeList.Domain.Service;
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

            // Match paused and watched anime sections
            Match pausedAnimeMatch = Regex.Match(inputText, pausedAnimePattern, RegexOptions.Singleline);
            Match watchedAnimeMatch = Regex.Match(inputText, watchedAnimePattern, RegexOptions.Singleline);

            if (pausedAnimeMatch.Success)
            {
                // Parse paused anime entries
                string pausedAnimeText = pausedAnimeMatch.Groups[1].Value;
                //var pausedAnimes = ParseAnimeEntries(pausedAnimeText, EnMediaStatus.Completed);
                //animes.AddRange(pausedAnimes);
            }

            if (watchedAnimeMatch.Success)
            {
                // Parse watched anime entries
                string watchedAnimeText = watchedAnimeMatch.Groups[1].Value;
                //var watchedAnimes = ParseAnimeEntries(watchedAnimeText, EnMediaStatus.Completed);
                //animes.AddRange(watchedAnimes);
            }

            return animes;
        }

        public static List<Anime> ParseAnimeEntries(string text, EnMediaStatus status)
        {
            var animeList = new List<Anime>();

            

            return animeList;
        }
    }
}

