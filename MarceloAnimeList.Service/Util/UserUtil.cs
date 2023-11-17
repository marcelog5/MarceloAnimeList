using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Data.Repository;
using MarceloAnimeList.Domain.Util;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace MarceloAnimeList.Service.Util
{
    public class UserUtil : IUserUtil
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public UserUtil
        (
            IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository
        )
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public string GetHashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public async Task<User> GetCurrentUser()
        {
            // Get the current user's claims
            var claims = _httpContextAccessor?.HttpContext?.User.Claims;

            // Retrieve the SID (User ID) claim
            var userIdClaim = claims?.FirstOrDefault(c => c.Type == "sid");

            if (userIdClaim is null)
            {
                return null;
            }

            User user = await _userRepository.GetByIdAsync(Guid.Parse(userIdClaim.Value));

            return user;
        }
    }
}
