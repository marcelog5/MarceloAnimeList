using AutoMapper;
using MarceloAnimeList.Domain.Command.UserComponents;
using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Data.Repository;
using MarceloAnimeList.Domain.Service;

namespace MarceloAnimeList.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService
        (
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResult> Create(CreateUserCommand command)
        {
            User user = _mapper.Map<User>(command);

            _userRepository.CreateAsync(user);

            return new CreateUserCommandResult()
            {
                Sucess = true,
                Result = _mapper.Map<CreateUserCommandResponse>(user)
            };
        }
    }
}
