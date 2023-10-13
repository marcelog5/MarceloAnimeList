using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Service.Command.FileParse;
using MarceloAnimeList.Service.Command.FileParse.AnimeParse;
using System.Text.RegularExpressions;

namespace MarceloAnimeList.Service.Service
{
    public class FileService : IFileService
    {
        public List<Media> Parser(string content)
        {
            var animes = ParseAnimeText(content);
            return new List<Media>();
        }

        public static List<Anime> ParseAnimeText(string inputText)
        {
            List<Anime> animes = new List<Anime>();

            var sectionParsers = new Dictionary<string, Type>
            {
                { "--animes em pausa--(.*?)--Animes assistidos--", typeof(PausedAnimeParser) },
                { "--Animes assistidos--(.*?)-- filme de anime assistidos --", typeof(WatchedAnimeParser) },
                { "-- animes possiveis --", typeof(PossibleAnimeParser) }
            };

            foreach (var (pattern, parserType) in sectionParsers)
            {
                Match match = Regex.Match(inputText, pattern, RegexOptions.Singleline);

                if (match.Success)
                {
                    string sectionText = match.Groups[1].Value;
                    var parser = (IMediaParser<Anime>)Activator.CreateInstance(typeof(IMediaParser<>).MakeGenericType(parserType));
                    animes.AddRange(parser.HandleParser(sectionText));
                }
            }

            return animes;
        }
    }

}

