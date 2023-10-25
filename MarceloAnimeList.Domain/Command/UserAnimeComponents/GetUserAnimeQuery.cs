using Commom.DomainLayer.Query;

namespace MarceloAnimeList.Domain.Command.UserAnimeComponents
{
    public class GetUserAnimeQuery : IQueryInput
    {
        public bool? WeeklyAnime { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
    }
}
