using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Enum;
using MarceloAnimeList.Service.Command.FileParse.MediaParse;

namespace MarceloAnimeList.Service.Command.FileParse.AnimeParse
{
    public class WatchedAnimeParser : TemplateMediaParser<UserAnime>
    {
        protected override List<UserAnime> parseMediaLine(string line)
        {
            try
            {
                List<UserAnime> userAnimes = new List<UserAnime>();

                string[] parts = line.Split(new string[] { " - ", "(", "/", ")", ";", ";", ";" }, StringSplitOptions.None)
                    .Where(l => !string.IsNullOrEmpty(l)).ToArray();
                
                int collumn = 0;
                string title = parts[collumn++];
                if (title.Contains("107")) 
                    collumn = 1;

                if (title.Split(".").Length == 2)
                    title = title.Split(".")[1];

                MediaGenreParser genreParser = new MediaGenreParser();
                EnMediaGenreType animeGenre = genreParser.AnimeGenre(parts[collumn].ToLower().Trim());

                double myAnimeListScore = Convert.ToDouble(parts[++collumn].ToLower().Replace("mal-","").Trim());
                double personScore = Convert.ToDouble(parts[++collumn].ToLower().Replace("np-","").Trim());

                collumn = 5;
                bool ovaSeason = parts.Any(p => p.ToLower().Contains("ova"));
                if (ovaSeason) collumn++;

                bool specialSeason = parts.Any(p => p.ToLower().Contains("especi"));
                if (specialSeason) collumn++;

                int seasons = Convert.ToInt32(parts[collumn].ToLower().Replace("temp", "").Trim());

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
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
