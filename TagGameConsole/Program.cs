using Microsoft.Extensions.DependencyInjection;
using System;
using TagGameBLL.Classes;

namespace TagGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            var gameManager = serviceProvider.GetService<IGameManager>();
            gameManager.StartGame(5, 1);
            var field = gameManager.GetField();
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    Console.Write(field[row, column] + " ");
                }
                Console.Write("\n");
            }

            while (true)
            {
                Console.ReadKey();
                gameManager.MoveCell(1);
                Console.Clear();
                field = gameManager.GetField();
                for (int row = 0; row < 5; row++)
                {
                    for (int column = 0; column < 5; column++)
                    {
                        Console.Write(field[row, column] + " ");
                    }
                    Console.Write("\n");
                }
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGameManager, GameManager>();
            services.AddTransient<CommandManager, CommandManager>();
            services.AddTransient<IFieldCreator, FieldCreator>();
        }

    }
}
