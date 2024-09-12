using System.Security.AccessControl;

namespace BookMyHome.Domain.Enitity;

public class Host : DomainEntity
{
    public List<Accommodation> accommodations { get; protected set; }
}