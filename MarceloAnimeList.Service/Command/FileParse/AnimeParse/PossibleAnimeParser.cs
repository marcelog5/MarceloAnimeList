using MarceloAnimeList.Domain.Entity;

namespace MarceloAnimeList.Service.Command.FileParse.AnimeParse
{
    public class PossibleAnimeParser : TemplateMediaParser<Anime>
    {
        protected override Anime parseMediaLine(string line)
        {
            throw new NotImplementedException();
        }
    }
}
