using BookMyHome.Application;
using BookMyHome.Domain.Enitity;

namespace BookMyHome.Infrastructure;

public class HostRepository : IHostRepository
{
    private readonly BookMyHomeContext _db;

    public HostRepository(BookMyHomeContext context)
    {
        _db = context;
    }
    Host IHostRepository.GetHost(int id)
    {
        return _db.Hosts.Single(h => h.Id == id);
    }

    void IHostRepository.AddHost(Host host)
    {
        throw new NotImplementedException();
    }

    void IHostRepository.DeleteHost(Host host, byte[] rowVersion)
    {
        throw new NotImplementedException();
    }



    void IHostRepository.UpdateHost(Host host, byte[] rowVersion)
    {
        throw new NotImplementedException();
    }
}