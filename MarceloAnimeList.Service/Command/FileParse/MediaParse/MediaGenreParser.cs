using MarceloAnimeList.Domain.Enum;

namespace MarceloAnimeList.Service.Command.FileParse.MediaParse
{
    public class MediaGenreParser
    {
        public EnMediaGenreType AnimeGenre(string genre)
        {
            Dictionary<string, EnMediaGenreType> genreMapping = new Dictionary<string, EnMediaGenreType>
            {
                { "ação", EnMediaGenreType.Action },
                { "aventura", EnMediaGenreType.Adventure },
                { "comédia", EnMediaGenreType.Comedy },
                { "drama", EnMediaGenreType.Drama },
                { "fantasia", EnMediaGenreType.Fantasy },
                { "horror", EnMediaGenreType.Horror },
                { "mistério", EnMediaGenreType.Mystery },
                { "romance", EnMediaGenreType.Romance },
                { "ficção científica", EnMediaGenreType.SciFi },
                { "slice of life", EnMediaGenreType.SliceOfLife },
                { "esporte", EnMediaGenreType.Sports },
                { "suspense", EnMediaGenreType.Thriller }
            };

            genre = genre.ToLower(); // Convert the input genre to lowercase for consistency

            if (genreMapping.ContainsKey(genre))
            {
                return genreMapping[genre];
            }
            else
            {
                Console.WriteLine($"Unrecognized Genre: {genre}");
                return EnMediaGenreType.Other; // Return a default value for unrecognized genres
            }
        }
    }
}
