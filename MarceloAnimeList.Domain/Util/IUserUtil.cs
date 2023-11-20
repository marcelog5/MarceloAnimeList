using MarceloAnimeList.Domain.Data.Entity;

namespace MarceloAnimeList.Domain.Util
{
    public interface IUserUtil
    {
        string GetHashPassword(string password);
        Task<User> GetCurrentUser();
    }
}
