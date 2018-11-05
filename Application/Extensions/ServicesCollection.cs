using System.Net.Http;
using System.Reflection;
using Application.Services;
using Infrastructure.ConnectionClient;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ServicesCollection
    {
        public static void AddDependency(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddScoped<IClient, Client>();
            services.AddScoped<IExchangeRateService, ExchangeRateService>();

            services.AddSingleton(p=> new HttpClient());
        }
    }
}