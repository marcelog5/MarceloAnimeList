using Commom.DomainLayer.Query;

namespace MarceloAnimeList.Domain.Command.UserAnimeComponents.Query
{
    public class GetUserAnimeQueryResult : IQueryResult<GetUserAnimeQueryResponse>
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public IList<Exception>? exceptions { get; set; }
        public GetUserAnimeQueryResponse? Result { get; set; }
    }
}
