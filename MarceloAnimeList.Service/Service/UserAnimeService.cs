using AutoMapper;
using MarceloAnimeList.Domain.Command.UserAnimeComponents.Command;
using MarceloAnimeList.Domain.Command.UserAnimeComponents.Query;
using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Data.Repository;
using MarceloAnimeList.Domain.Enum;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Service.Service.HttpService;

namespace MarceloAnimeList.Service.Service
{
    public class UserAnimeService : IUserAnimeService
    {
        private MALHttpClient _httpClient;
        private readonly IUserAnimeRepository _userAnimeRepository;
        private readonly IMapper _mapper;

        public UserAnimeService
        (
            MALHttpClient httpClient,
            IUserAnimeRepository userAnimeRepository,
            IMapper mapper
        )
        {
            _httpClient = httpClient;
            _userAnimeRepository = userAnimeRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserAnimeCommandResult> Create(CreateUserAnimeCommand command)
        {
            var anime = await _httpClient.GetAnime("Boku dake ga Inai Machi");

            throw new NotImplementedException();
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
