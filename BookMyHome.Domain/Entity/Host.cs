using System.Security.AccessControl;

namespace BookMyHome.Domain.Enitity;

public class Host : DomainEntity
{
    public List<Accommodation> Accommodations { get; protected set; }

    public Host()
    {

    }
}