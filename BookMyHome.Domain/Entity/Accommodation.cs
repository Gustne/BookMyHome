using System.Drawing;

namespace BookMyHome.Domain.Enitity;

public class Accommodation : DomainEntity
{
    public Host Host { get; protected set; }

    public List<Booking> Bookings { get; protected set; }

    protected Accommodation()
    {
        
    }


    public Accommodation(Host host)
    {
        Host = host;
    }

    public static Accommodation Create(Host host)
    {
        return new Accommodation(host);
    }


    public void Update(Host host)
    {
        Host = host;
    }

}