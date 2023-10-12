using MarceloAnimeList.Domain.Entity;

namespace MarceloAnimeList.Service.Command.FileParse.AnimeParse
{
    public class PausedAnimeParser : IMediaParser<Anime>
    {
        public List<Anime> HandleParser(string content)
        {
            List<Anime> pausedAnimeList = new List<Anime>();

            string[] pausedAnimeLines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            pausedAnimeLines = pausedAnimeLines.Where(pal => !(string.IsNullOrWhiteSpace(pal) && pal.Contains("\r"))).ToArray(); 

            foreach (var line in pausedAnimeLines)
            {
                string[] parts = line.Replace("\r","").Split(new string[] { "ep:" }, StringSplitOptions.None);

                // Extract the title and episode from the matched groups
                string title = parts[0].Trim();
                int episode = 0;

                if (parts.Length == 2)
                    episode = int.Parse(parts[1].Trim());

                // Create an Anime object with the title
                Anime anime = new Anime
                {
                    Title = title
                };

                pausedAnimeList.Add(anime);
            }

            return pausedAnimeList;
        }
    }
}
