using Commom.DomainLayer.Command;
using MarceloAnimeList.Domain.Service;

namespace MarceloAnimeList.Commands.ImportAnimeList
{
    public class Import : ICLICommand
    {
        private readonly string[] _args;
        private readonly IFileService _fileService;

        public Import
        (
            IFileService fileService,
            string[] args
        )
        {
            _fileService = fileService;
            _args = args;
        }

        public void Execute()
        {
            try
            {
                string filePath = _args[1];

                // Verifique se o arquivo existe
                if (File.Exists(filePath))
                {
                    // Realize a leitura do arquivo
                    string content = File.ReadAllText(filePath);

                    // Exiba o conteúdo do arquivo
                    Console.WriteLine("Conteúdo do arquivo:");
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine("O arquivo não foi encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao importar o arquivo: " + ex.Message);
            }
        }
    }
}
