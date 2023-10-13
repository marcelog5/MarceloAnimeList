using MarceloAnimeList.Domain.Data.Entity;

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
