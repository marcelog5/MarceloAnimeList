using AutoMapper;
using MarceloAnimeList.Domain.Command.UserAnimeComponents.Command;
using MarceloAnimeList.Domain.Command.UserAnimeComponents.Query;
using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Data.Model;
using MarceloAnimeList.Domain.Data.Repository;
using MarceloAnimeList.Domain.Enum;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Domain.Util;
using MarceloAnimeList.Service.Service.HttpService;

namespace MarceloAnimeList.Service.Service
{
    public class UserAnimeService : IUserAnimeService
    {
        private MALHttpClient _httpClient;
        private readonly IUserAnimeRepository _userAnimeRepository;
        private readonly IMapper _mapper;
        private readonly IUserUtil _userUtil;

        public UserAnimeService
        (
            MALHttpClient httpClient,
            IUserAnimeRepository userAnimeRepository,
            IMapper mapper,
            IUserUtil userUtil
        )
        {
            _httpClient = httpClient;
            _userAnimeRepository = userAnimeRepository;
            _mapper = mapper;
            _userUtil = userUtil;
        }

        public async Task<CreateUserAnimeCommandResult> Create(CreateUserAnimeCommand command)
        {
            MyAnimeListModel anime = await _httpClient.GetAnime("Boku dake ga Inai Machi");

            if ( anime == null )
            {
                return new CreateUserAnimeCommandResult()
                {
                    Success = false,
                    ErrorMessage = "ANIME_NOT_FOUND"
                };
            }

            User user = _userUtil.GetCurrentUser();

            UserAnime userAnime = new UserAnime();
            userAnime.User = user;

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
                Success = true,
                Result = _mapper.Map<GetUserAnimeQueryResponse>(userAnimes)
            };
        }
    }
}
