using Microsoft.Extensions.DependencyInjection;

namespace Kodj.Consul
{
    public class ConsulServiceBuilder
    {
        private readonly IServiceCollection _serviceCollection;
        
        public ConsulServiceBuilder(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }
    }
}