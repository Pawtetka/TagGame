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

            var presenter = serviceProvider.GetService<Presenter>();
            presenter.ShowMenu();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGameManager, GameManager>();
            services.AddTransient<ICommandManager, CommandManager>();
            services.AddTransient<IFieldCreator, FieldCreator>();
            services.AddTransient<Presenter, Presenter>();
            services.AddTransient<IView, View>();
        }
    }
}
