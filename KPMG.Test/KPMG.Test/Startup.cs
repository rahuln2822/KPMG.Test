using KPMG.Processor;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Processor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KPMG.Test
{
    public class Startup
    {
        public static IHost ConfigureHost(IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) => ConfigureServices(context, services));

            return hostBuilder.Build();
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", optional: true)
                             .Build();


            var appsettings = configuration.GetSection("CosmosDbSettings").Get<CosmosDbSettings>();
            services.AddSingleton(appsettings);
            services.AddSingleton(new AzureServiceTokenProvider());
            services.AddSingleton<AzureAuthHandler>();
            services.AddTransient<INestedObjectChallenge, NestedObjectChallenge>();
            services.AddTransient<IMetadataChallenge, MetadataChallenge>();
            services.AddHttpClient<ICosmosDbMetadata, CosmosDbMetadata>(client => {
                client.BaseAddress = new Uri("https://management.azure.com/");
            }).AddHttpMessageHandler<AzureAuthHandler>();
            
        }
    }
}
