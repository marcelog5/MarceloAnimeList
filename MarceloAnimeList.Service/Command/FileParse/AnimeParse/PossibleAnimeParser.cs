using MarceloAnimeList.Domain.Data.Entity;

namespace MarceloAnimeList.Service.Command.FileParse.AnimeParse
{
    public class PossibleAnimeParser : TemplateMediaParser<UserAnime>
    {
        protected override UserAnime parseMediaLine(string line)
        {
            throw new NotImplementedException();
        }
    }
}
