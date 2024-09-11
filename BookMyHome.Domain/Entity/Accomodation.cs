using System.Drawing;

namespace BookMyHome.Domain.Enitity;

public class Accomodation : DomainEntity
{
    public int HostId { get; protected set; }
    public Host Host { get; protected set; }

    public List<Booking> bookings { get; protected set; }

    protected Accomodation()
    {
        
    }

    private Accomodation(int hostId)
    {
        HostId = hostId;
    }

    public Accomodation(Host host)
    {
        Host = host;
    }

    public static Accomodation Create(Host host)
    {
        return new Accomodation(host);
    }

    public static Accomodation Create(int hostId)
    {
        return new Accomodation(hostId);
    }

    public void Update(Host host)
    {
        Host = host;
    }

    public void Update(int hostId)
    {
        HostId = hostId;
    }

}