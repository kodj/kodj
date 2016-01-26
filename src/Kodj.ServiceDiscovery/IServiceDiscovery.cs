namespace Kodj.ServiceDiscovery
{
    public interface IServiceDiscovery
    {
        void RegisterService(string serviceName, string endpoint, int port);
        void RemoveService(string serviceName, string endpoint, int port);
    }
}