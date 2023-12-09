using Common.DomainLayer.Query;

namespace MarceloAnimeList.Domain.Command.UserAnimeComponents.Query
{
    public class GetUserAnimeQuery : IQueryInput
    {
        public bool? WeeklyAnime { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
    }
}
