using Common.DomainLayer.Command;
using MarceloAnimeList.Commands.ImportAnimeList;
using MarceloAnimeList.Domain.Data.Repository;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Infra._4._1_Data.Repository;
using MarceloAnimeList.Service.Service;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    private static void Main(string[] args)
    {
        // Create a service collection.
        var commandProvider = new ServiceCollection()
            .AddTransient<ICLICommand, Import>()
            .AddTransient<IFileService, FileService>()
            .AddTransient<IUserRepository, UserRepository>()
            .BuildServiceProvider();

        // Resolve the service.
        var import = commandProvider.GetRequiredService<ICLICommand>();

        import.Execute(args);
    }
}