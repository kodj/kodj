using Kodj.ServiceDiscovery;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kodj.Api.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private IServiceDiscovery _consul;
        public ServicesController(IServiceDiscovery consul)
        {
            this._consul = consul;
        }

        [HttpGet("{servicename}")]
        public async Task<dynamic> Get(string serviceName)
        {
            System.Console.WriteLine(string.Format("Getting information from {0}", serviceName));
            var services = await _consul.GetService(serviceName);
            var service = services?[0];

            using (var httpClient = new HttpClient())
            {
                var url = string.Format("http://{0}:{1}/status", service.ServiceAddress, service.ServicePort);
                
                Console.WriteLine("Fetching data from {0}", url);
                
                var result = await httpClient.GetStringAsync(url);

                return new
                {
                    ServiceName = service.ServiceName,
                    ServerName = service.ServiceAddress,
                    Port = service.ServicePort,
                    Status = result
                };
            }
        }
    }
}
