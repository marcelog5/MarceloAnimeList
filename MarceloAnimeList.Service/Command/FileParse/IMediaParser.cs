namespace MarceloAnimeList.Service.Command.FileParse
{
    public interface IMediaParser<TResponse>
    {
        List<TResponse> HandleParser(string content);
    }
}
