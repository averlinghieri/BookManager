using BookManager.Application;
using BookManager.Application.Abstractions.Repositories;
using BookManager.Application.Abstractions.Services;
using BookManager.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookManager.UI
{
    internal class Program
    {
        public static IConfiguration Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        public static async Task Main(string[] args)
        {
            var connectionString = Configuration.GetConnectionString("BookManagerDB");

            using IHost host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            try
            {
                await services.GetRequiredService<App>().Run(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            IHostBuilder CreateHostBuilder(string[] strings)
            {
                return Host.CreateDefaultBuilder()
                    .ConfigureServices(services =>
                    {
                        services.AddSingleton(Configuration);
                        services.AddSingleton<IBookRepository, BookRepository>();
                        services.AddSingleton<IBookService, BookService>();
                        services.AddSingleton<IAuthorRepository, AuthorRepository>();
                        services.AddSingleton<IAuthorService, AuthorService>();
                        services.AddSingleton<App>();
                    })
                    ;
            }
        }
    }
}
