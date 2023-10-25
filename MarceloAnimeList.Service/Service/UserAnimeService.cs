using AutoMapper;
using MarceloAnimeList.Domain.Command.UserAnimeComponents;
using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Data.Repository;
using MarceloAnimeList.Domain.Enum;
using MarceloAnimeList.Domain.Service;

namespace MarceloAnimeList.Service.Service
{
    public class UserAnimeService : IUserAnimeService
    {
        private readonly IUserAnimeRepository _userAnimeRepository;
        private readonly IMapper _mapper;

        public UserAnimeService
        (
            IUserAnimeRepository userAnimeRepository,
            IMapper mapper
        )
        {
            _userAnimeRepository = userAnimeRepository;
            _mapper = mapper;
        }

        public async Task<GetUserAnimeQueryResult> Get(GetUserAnimeQuery query)
        {
            Func<IQueryable<UserAnime>, IQueryable<UserAnime>> filter = null;

            if (query.WeeklyAnime != null)
            {
                filter = f => f.Where(ua => ua.Anime.Status == EnMediaStatus.Airing
                                         && ua.Status == EnUserMediaStatus.CurrentlyWatching);
            }

            var userAnimes = await _userAnimeRepository.GetAsync(filter);

            return new GetUserAnimeQueryResult()
            {
                Sucess = true,
                Result = _mapper.Map<GetUserAnimeQueryResponse>(userAnimes)
            };
        }
    }
}
