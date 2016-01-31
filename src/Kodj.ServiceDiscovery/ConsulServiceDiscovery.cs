using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Kodj.ServiceDiscovery
{
    public class ConsulServiceDiscovery : IServiceDiscovery
    {
        public IConfigurationRoot Configuration { get; set; }
        public ConsulServiceDiscovery()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("consul.json");

            Configuration = builder.Build();
        }
        public async Task<List<ServiceMetadata>> GetService(string serviceName)
        {
            using (var httpClient = new HttpClient())
            {
                var url = string.Format("http://{0}:{1}/v1/catalog/service/{2}"
                    , Configuration["server:address"]
                    , Configuration["server:port"]
                    , serviceName);
                    
                System.Console.WriteLine("Fetching data from: {0}", url);
                
                var result = await httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<List<ServiceMetadata>>(result);
            }
        }

        public async Task RegisterService(string serviceName, string endpoint, int port)
        {

        }

        public async Task RemoveService(string serviceName, string endpoint, int port)
        {

        }


    }
}