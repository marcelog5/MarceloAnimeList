using Commom.DomainLayer.Query;

namespace MarceloAnimeList.Domain.Command.UserAnimeComponents
{
    public class GetUserAnimeQueryResult : IQueryResult<GetUserAnimeQueryResponse>
    {
        public bool Sucess { get; set; }
        public string? ErrorMessage { get; set; }
        public IList<Exception>? exceptions { get; set; }
        public GetUserAnimeQueryResponse? Result { get; set; }
    }
}
