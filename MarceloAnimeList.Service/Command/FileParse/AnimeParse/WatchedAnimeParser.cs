using MarceloAnimeList.Domain.Data.Entity;

namespace MarceloAnimeList.Service.Command.FileParse.AnimeParse
{
    public class WatchedAnimeParser : TemplateMediaParser<UserAnime>
    {
        protected override UserAnime parseMediaLine(string line)
        {
            string[] parts = line.Split(new string[] { " - ", "(", "/", ")", ";", ";", ";" }, StringSplitOptions.None)
                .Where(l => !string.IsNullOrEmpty(l)).ToArray();

            string title = parts[0];

            if (title.Split(".").Length == 2)
                title = title.Split(".")[1];

            string episodeInfo = parts[4].Trim();

            UserAnime userAnime = new UserAnime
            {
                Anime = new Anime { Title = title }
            };


            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Episode Info: {episodeInfo}");
            Console.WriteLine();

            return userAnime;
        }
    }
}
