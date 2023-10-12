using Commom.DomainLayer.Command;
using MarceloAnimeList.Commands.ImportAnimeList;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Service.Service;

public class Program
{
    private static void Main(string[] args)
    {
        IFileService fileService = new FileService();

        ICLICommand import = new Import(fileService, args);
        import.Execute();
    }
}