using MarceloAnimeList.Domain.Data.Entity;

namespace MarceloAnimeList.Service.Command.FileParse.AnimeParse
{
    public class PausedAnimeParser : TemplateMediaParser<Anime>
    {
        protected override Anime parseMediaLine(string line)
        {
            string[] parts = line.Split(new string[] { "ep:" }, StringSplitOptions.None);

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

            return anime;
        }
    }
}
