using KPMG.Test;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Threading;

namespace KPMG_Test
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("KPMG Challenge");
            var nestedObj = new Nested("x", new Nested("y", new Nested("z", "a")));

            var serviceProvider = GetServiceProvider();
            var nestedObjectChallenge = (INestedObjectChallenge)serviceProvider.GetService(typeof(INestedObjectChallenge));

            nestedObjectChallenge.Write(nestedObj);
            nestedObjectChallenge.Write(nestedObj, "y");

            var metadataChallenge = (IMetadataChallenge)serviceProvider.GetService(typeof(IMetadataChallenge));
            metadataChallenge.WriteMetadata(CancellationToken.None);

            Console.ReadLine();
        }

        private static IServiceProvider GetServiceProvider()
        {
            var host = Startup.ConfigureHost(new HostBuilder());
            return host.Services;
        }
    }
}
