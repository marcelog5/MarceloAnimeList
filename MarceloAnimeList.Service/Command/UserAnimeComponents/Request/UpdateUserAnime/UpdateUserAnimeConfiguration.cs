using MarceloAnimeList.Domain.Enum;

namespace MarceloAnimeList.Service.Command.UserAnimeComponents.Request.UpdateUserAnime
{
    public class UpdateUserAnimeConfiguration
    {
        public EnUserMediaStatus Status { get; set; }
        public int? Episode { get; set; }
    }
}
