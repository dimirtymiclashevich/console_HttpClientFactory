using Microsoft.Extensions.DependencyInjection;
using System;

namespace NamedClient
{
    class Program
    {
        public static IServiceProvider Container { get; private set; }

        static void Main()
        {
            // Configure services
            Container = RegisterServices();

            // in a galaxy far
            var client = new Client();
            var googleHtml = client.GetGoogle().GetAwaiter().GetResult();
            var amazonHtml = client.GetAmazon().GetAwaiter().GetResult();
        }

        private static IServiceProvider RegisterServices()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureHttpClients(serviceCollection);
            return serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureHttpClients(IServiceCollection services)
        {
            services.AddHttpClient("google", client =>
            {
                client.BaseAddress = new Uri("https://www.google.com/");
                client.DefaultRequestHeaders.Add("Accept", "text/html");
                client.DefaultRequestHeaders.Add("User-Agent", "vojo");
            });

            services.AddHttpClient("amazon", client =>
            {
                client.BaseAddress = new Uri("https://www.amazon.com/");
                client.DefaultRequestHeaders.Add("Accept", "text/html");
                client.DefaultRequestHeaders.Add("User-Agent", "vojo");
            });
        }
    }
}
