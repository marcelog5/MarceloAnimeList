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
        private readonly IAnimeRepository _animeRepository;
        private readonly IMapper _mapper;
        private readonly IUserUtil _userUtil;

        public UserAnimeService
        (
            MALHttpClient httpClient,
            IUserAnimeRepository userAnimeRepository,
            IAnimeRepository animeRepository,
            IMapper mapper,
            IUserUtil userUtil
        )
        {
            _httpClient = httpClient;
            _userAnimeRepository = userAnimeRepository;
            _animeRepository = animeRepository;
            _mapper = mapper;
            _userUtil = userUtil;
        }

        public async Task<CreateUserAnimeCommandResult> Create(CreateUserAnimeCommand command)
        {
            MyAnimeListModel anime = await _httpClient.GetAnime(command.AnimeName);

            if ( anime is null || !anime.data.Any())
            {
                return new CreateUserAnimeCommandResult()
                {
                    Success = false,
                    ErrorMessage = "ANIME_NOT_FOUND"
                };
            }

            MyAnimeListModelData animeData = GetAnimeSeason(anime.data, command.Season);

            if (animeData is null)
            {
                return new CreateUserAnimeCommandResult()
                {
                    Success = false,
                    ErrorMessage = "ANIME_NOT_FOUND"
                };
            }

            UserAnime userAnime = new UserAnime();

            // User section
            User user = await _userUtil.GetCurrentUser();
            userAnime.UserId = user.Id;

            // Anime Section
            Func<IQueryable<Anime>, IQueryable<Anime>> filter = f => 
                    f.Where(a => a.Title.ToLower() == animeData.title.ToLower()
                              && a.Season == command.Season);
            var result = await _animeRepository.GetAsync(filter);

            if (result is null || !result.Any())
            {
                Dictionary<string, EnMediaGenreType> animeGenreDic = new Dictionary<string, EnMediaGenreType>()
                {
                    { "Adventure", EnMediaGenreType.Adventure },
                    { "Sci-Fi", EnMediaGenreType.SciFi },
                    { "Action", EnMediaGenreType.Action },
                    { "Drama", EnMediaGenreType.Drama }
                };

                Dictionary<string, EnMediaStatus> animeStatusDic = new Dictionary<string, EnMediaStatus>()
                {
                    { "Currently Airing", EnMediaStatus.Airing },
                    { "Finished Airing", EnMediaStatus.Upcoming },
                    { "Not yet aired", EnMediaStatus.Completed }
                };

                userAnime.Anime = _mapper.Map<Anime>(animeData);
                userAnime.Anime.Season = command.Season;
                userAnime.Anime.Status = animeStatusDic[animeData.status];
                userAnime.Anime.Type = EnAnimeType.TVSeries;

                string firstGenre = animeData.genres.FirstOrDefault().name;
                userAnime.Anime.Genre = animeGenreDic.ContainsKey(firstGenre) ? animeGenreDic[firstGenre] : EnMediaGenreType.Other;

                // Rating Section
                userAnime.Anime.Ratings = new List<Rating> { new Rating()
                {
                    Active = true,
                    Type = EnRatingType.MyAnimeList,
                    Score = animeData.score,
                    UserId = user.Id
                }};
            }
            else
            {
                userAnime.AnimeId = result.SingleOrDefault().Id;
            }

            // User anime section
            userAnime.Episode = command.Episode;
            userAnime.Status = command.UserAnimeStatus;

            userAnime = await _userAnimeRepository.CreateAsync(userAnime);

            return new CreateUserAnimeCommandResult()
            {
                Success = true,
                Result = _mapper.Map<CreateUserAnimeCommandResponse>(userAnime)
            };
        }
        
        private MyAnimeListModelData GetAnimeSeason(IList<MyAnimeListModelData> animes, int season)
        {
            animes = animes.Where(a => a.type.ToLower() == "tv").ToList();

            animes.OrderBy(a => a.aired.from);

            if (animes.Count >= season)
                return animes[season - 1];
            else
                return null;
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
