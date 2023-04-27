using App.Core;
using App.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
              .AddSingleton<ParserService>()
              .AddSingleton<IMultiValueRepository, MultiValueRepository>()
              .BuildServiceProvider();

            var parserService = serviceProvider.GetService<ParserService>();

            ArgumentNullException.ThrowIfNull(parserService, nameof(parserService));

            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    return;

                parserService.ProcessInput(Console.ReadLine());
            }
        }
    }
}