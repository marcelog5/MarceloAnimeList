namespace MarceloAnimeList.Domain.Command.UserAnimeComponents.Query
{
    public class GetUserAnimeQueryResponse
    {
        public List<UserAnimeResponse> UserAnimes { get; set; }
    }

    public class UserAnimeResponse
    {
        public string Title { get; set; }
    }
}
