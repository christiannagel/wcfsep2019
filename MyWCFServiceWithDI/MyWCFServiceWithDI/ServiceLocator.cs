using CalculatorLib;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MyWCFServiceWithDI
{
    public class ServiceLocator
    {
        public IServiceProvider Services { get; }
        private ServiceLocator()
        {
            Services = GetServices();
        }

        private IServiceProvider GetServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<ITheBestCalculator, TheBestCalculator>();
            services.AddLogging(config =>
            {
                config.AddConsole();
            });

            return services.BuildServiceProvider();
        }

        public static ServiceLocator Instance
        {
            get => GetLocator();
        }

        private static ServiceLocator _instance;
        private static ServiceLocator GetLocator()
        {
            return _instance ?? (_instance = new ServiceLocator());
        }
    }
}
