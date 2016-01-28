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
            var services = await _consul.GetService(serviceName);
            var service = services?[0];

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetStringAsync(string.Format("http://{0}:{1}/status", service.Address, service.ServicePort));

                return new
                {
                    ServiceName = service.ServiceName,
                    ServerName = service.Address,
                    Port = service.ServicePort,
                    Status = result
                };
            }
        }
    }
}
