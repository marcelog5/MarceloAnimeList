using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Enum;

namespace MarceloAnimeList.Service.Command.FileParse.AnimeParse
{
    public class PossibleAnimeParser : TemplateMediaParser<UserAnime>
    {
        protected override List<UserAnime> parseMediaLine(string line)
        {
            // Create an Anime object with the title
            UserAnime userAnime = new UserAnime
            {
                Anime = new Anime
                {
                    Title = line,
                    Type = EnAnimeType.TVSeries,
                    Season = 1
                },
                Status = EnUserMediaStatus.PlanToWatch
            };

            return new List<UserAnime>() { userAnime };
        }
    }
}
