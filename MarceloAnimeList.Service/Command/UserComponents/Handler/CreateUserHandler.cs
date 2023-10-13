using AutoMapper;
using MarceloAnimeList.Domain.Command.UserComponents;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Service.Command.UserComponents.Request;
using MediatR;

namespace MarceloAnimeList.Service.Command.UserComponents.Handler
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, object>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateUserHandler
        (
            IUserService userService,
            IMapper mapper
        )
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<object> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateUserCommand>(request);

            var result = await _userService.Create(command);

            return result;
        }
    }
}
