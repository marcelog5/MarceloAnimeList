using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Enum;
using MarceloAnimeList.Service.Command.FileParse.MediaParse;

namespace MarceloAnimeList.Service.Command.FileParse.AnimeParse
{
    public class WatchedAnimeParser : TemplateMediaParser<UserAnime>
    {
        protected override List<UserAnime> parseMediaLine(string line)
        {
            List<UserAnime> userAnimes = new List<UserAnime>();

            string[] parts = line.Split(new string[] { " - ", "(", "/", ")", ";", ";", ";" }, StringSplitOptions.None)
                .Where(l => !string.IsNullOrEmpty(l)).ToArray();

            string title = parts[0];

            if (title.Split(".").Length == 2)
                title = title.Split(".")[1];

            MediaGenreParser genreParser = new MediaGenreParser();
            EnMediaGenreType animeGenre = genreParser.AnimeGenre(parts[1].ToLower().Trim());

            double personScore = Convert.ToDouble(parts[3].ToLower().Replace("np-","").Trim());

            int seasons = Convert.ToInt32(parts[5].ToLower().Replace("temp", "").Trim());
            bool ovaSeason = parts.Any(p => p.ToLower().Contains("ova"));
            bool specialSeason = parts.Any(p => p.ToLower().Contains("especi"));

            for (int i = 0; i < seasons; i++)
            {
                UserAnime userAnime = new UserAnime
                {
                    Anime = new Anime 
                    { 
                        Title = title,
                        Genre = animeGenre,
                        Season = i + 1,
                        Type = EnAnimeType.TVSeries
                    }
                };

                userAnimes.Add(userAnime);
            }

            if(ovaSeason)
                userAnimes.Add(new UserAnime
                {
                    Anime = new Anime
                    {
                        Title = title,
                        Genre = animeGenre,
                        Type = EnAnimeType.OVA
                    }
                });

            if (specialSeason)
                userAnimes.Add(new UserAnime
                {
                    Anime = new Anime
                    {
                        Title = title,
                        Genre = animeGenre,
                        Type = EnAnimeType.OVA
                    }
                });

            return userAnimes;
        }
    }
}
