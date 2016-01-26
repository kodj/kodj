using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using JetBrains.Annotations;
using Kodj.ServiceDiscovery;

namespace Kodj.Consul.Extensions.DependencyInjection
{
    public static class ConsulServiceCollectionExtensions
    {
        public static ConsulServiceBuilder AddConsul([NotNull]this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IServiceDiscovery, ConsulServiceDiscovery>();
            
            return new ConsulServiceBuilder(serviceCollection);
        }
    }
}
