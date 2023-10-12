namespace MarceloAnimeList.Service.Command.FileParse
{
    public interface IMediaParser<TMedia>
    {
        IList<TMedia> HandleParser(string content);
    }
}
