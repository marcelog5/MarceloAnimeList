namespace MarceloAnimeList.Service.Command.FileParse
{
    public abstract class TemplateMediaParser<TMedia> : IMediaParser<TMedia>
        where TMedia : class
    {
        public virtual IList<TMedia> HandleParser(string content)
        {
            IList<TMedia> mediaList = new List<TMedia>();

            string[] mediaLines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            mediaLines = mediaLines.Where(pal => !(string.IsNullOrWhiteSpace(pal) && pal.Contains("\r"))).ToArray();

            foreach (var line in mediaLines)
            {
                List<TMedia> medias = parseMediaLine(line.Replace("\r","").Replace("\t",""));
                medias.ForEach(m => mediaList.Add(m));
            }

            return mediaList;
        }

        protected abstract List<TMedia> parseMediaLine(string line);
    }
}
