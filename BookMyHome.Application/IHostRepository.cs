using BookMyHome.Domain.Enitity;

namespace BookMyHome.Application;

public interface IHostRepository
{
    Host GetHost(int id);
    void AddHost(Host host);
    void UpdateHost(Host host, byte[] rowVersion);
    void DeleteHost(Host host, byte[] rowVersion);
}