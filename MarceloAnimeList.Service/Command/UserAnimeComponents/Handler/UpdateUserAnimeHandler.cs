using AutoMapper;
using MarceloAnimeList.Domain.Command.UserAnimeComponents.Command;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Service.Command.UserAnimeComponents.Request.UpdateUserAnime;
using MediatR;

namespace MarceloAnimeList.Service.Command.UserAnimeComponents.Handler
{
    public class UpdateUserAnimeHandler : IRequestHandler<UpdateUserAnimeRequest, UpdateUserAnimeCommandResult>
    {
        private readonly IUserAnimeService _userAnimeService;
        private readonly IMapper _mapper;

        public UpdateUserAnimeHandler
        (
            IUserAnimeService userAnimeService,
            IMapper mapper
        )
        {
            _userAnimeService = userAnimeService;
            _mapper = mapper;
        }

        public async Task<UpdateUserAnimeCommandResult> Handle(UpdateUserAnimeRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateUserAnimeCommand>(request.Configuration);

            var result = await _userAnimeService.Update(command);

            return result;
        }
    }
}
