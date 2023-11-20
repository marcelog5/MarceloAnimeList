using AutoMapper;
using MarceloAnimeList.Domain.Command.UserComponents;
using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Data.Repository;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Domain.Util;
using MarceloAnimeList.Service.Util;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarceloAnimeList.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserUtil _userUtil;

        public UserService
        (
            IUserRepository userRepository,
            IUserUtil userUtil,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _userUtil = userUtil;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResult> Create(CreateUserCommand command)
        {
            User user = _mapper.Map<User>(command);

            user.Password = _userUtil.GetHashPassword(command.Password);

            await _userRepository.CreateAsync(user);

            return new CreateUserCommandResult()
            {
                Success = true,
                Result = _mapper.Map<CreateUserCommandResponse>(user)
            };
        }

        public async Task<LoginCommandResult> Login(LoginCommand command)
        {
            var password = _userUtil.GetHashPassword(command.Password);

            Func<IQueryable<User>, IQueryable<User>> filter = f => f.Where(u => u.Email == command.Email
                                                                             && u.Password == password);

            User user = (await _userRepository.GetAsync(filter)).SingleOrDefault();

            if (user is not null)
            {
                // Define your secret key (keep it secure!)
                string secretKey = "YourSecretKeyHere123456789012345678901234567890";

                // Create claims for the user
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                };

                // Create a symmetric security key
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                // Create signing credentials using the key and algorithm
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Create a JWT token
                var token = new JwtSecurityToken(
                    issuer: null,
                    audience: null,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: creds
                );

                // Serialize the token to a string
                string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                // Return the token in your result
                return new LoginCommandResult()
                {
                    Success = true,
                    Result = new LoginCommandResponse()
                    {
                        Token = tokenString
                    }
                };
            }

            return new LoginCommandResult()
            {
                Success = false
            };
        }
    }
}
