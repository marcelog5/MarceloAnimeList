using AutoMapper;
using MarceloAnimeList.Domain.Command.UserAnimeComponents.Command;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Service.Command.UserAnimeComponents.Request;
using MediatR;

namespace MarceloAnimeList.Service.Command.UserAnimeComponents.Handler
{
    public class CreateUserAnimeHandler : IRequestHandler<CreateUserAnimeRequest, CreateUserAnimeCommandResult>
    {
        private readonly IUserAnimeService _userAnimeService;
        private readonly IMapper _mapper;

        public CreateUserAnimeHandler
        (
            IUserAnimeService userAnimeService,
            IMapper mapper
        )
        {
            _userAnimeService = userAnimeService;
            _mapper = mapper;
        }
        public async Task<CreateUserAnimeCommandResult> Handle(CreateUserAnimeRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateUserAnimeCommand>(request);

            var result = await _userAnimeService.Create(command);

            return result;
        }
    }
}
