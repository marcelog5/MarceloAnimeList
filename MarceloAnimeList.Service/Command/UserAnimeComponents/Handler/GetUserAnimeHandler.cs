using AutoMapper;
using MarceloAnimeList.Domain.Command.UserAnimeComponents;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Service.Command.UserAnimeComponents.Request;
using MediatR;

namespace MarceloAnimeList.Service.Command.UserAnimeComponents.Handler
{
    public class GetUserAnimeHandler : IRequestHandler<GetUserAnimeRequest, GetUserAnimeQueryResult>
    {
        private readonly IUserAnimeService _userAnimeService;
        private readonly IMapper _mapper;

        public GetUserAnimeHandler
        (
            IUserAnimeService userAnimeService,
            IMapper mapper
        )
        {
            _userAnimeService = userAnimeService;
            _mapper = mapper;
        }

        public async Task<GetUserAnimeQueryResult> Handle(GetUserAnimeRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetUserAnimeQuery>(request);

            var result = await _userAnimeService.Get(query);

            return result;
        }
    }
}
