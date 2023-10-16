using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Enum;

namespace MarceloAnimeList.Service.Command.FileParse.AnimeParse
{
    public class PausedAnimeParser : TemplateMediaParser<UserAnime>
    {
        protected override List<UserAnime> parseMediaLine(string line)
        {
            string[] parts = line.Split(new string[] { "ep:" }, StringSplitOptions.None);

            // Extract the title and episode from the matched groups
            string title = parts[0].Trim();
            int episode = 0;

            if (parts.Length == 2)
                episode = int.Parse(parts[1].Trim());

            // Create an Anime object with the title
            UserAnime userAnime = new UserAnime
            {
                Anime = new Anime 
                { 
                    Title = title,
                    Type = EnAnimeType.TVSeries,
                    Season = 1
                },
                Episode = episode,
                Status = EnUserMediaStatus.StopWatching
            };

            return new List<UserAnime>() { userAnime };
        }
    }
}
