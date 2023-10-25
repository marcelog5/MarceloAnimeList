using MarceloAnimeList.Domain.Command.UserAnimeComponents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarceloAnimeList.Service.Command.UserAnimeComponents.Request
{
    public class GetUserAnimeRequest : IRequest<GetUserAnimeQueryResult>
    {
        [FromQuery]
        public bool? WeeklyAnime { get; set; }
        [FromQuery]
        public DayOfWeek? DayOfWeek { get; set; }
    }
}
