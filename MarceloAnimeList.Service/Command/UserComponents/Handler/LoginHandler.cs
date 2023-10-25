using AutoMapper;
using MarceloAnimeList.Domain.Command.UserComponents;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Service.Command.UserComponents.Request;
using MediatR;

namespace MarceloAnimeList.Service.Command.UserComponents.Handler
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginCommandResult>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginHandler
        (
            IUserService userService,
            IMapper mapper
        )
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<LoginCommandResult> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<LoginCommand>(request);

            var result = await _userService.Login(command);

            return result;
        }
    }
}
