using System;
using System.IO;
using Enigma.Machine;
using Enigma.Rotors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Enigma
{
    class Program
    {
        static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ConsoleApplication>().Run();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false)
                .Build();

            services.AddLogging(config =>
                {
                    _ = config.AddConfiguration(configuration.GetSection("Logging"))
                            .AddConsole()
                            .AddDebug();
                });

            services.Configure<Enigma.Machine.EnigmaB.RotorSettings>(configuration.GetSection("RotorSettings"));

            services.AddSingleton<IRotorFactory, Enigma.Rotors.EnigmaI.RotorFactory>();
            services.AddSingleton<IScramblerUnit, Enigma.Machine.EnigmaB.ScramblerUnit>();
            services.AddSingleton<ConsoleApplication>();

            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
                return;

            if (_serviceProvider is IDisposable)
                ((IDisposable)_serviceProvider).Dispose();
        }
    }
}
