namespace BookMyHome.Domain.Enitity;

public class Guest : DomainEntity
{
    List<Booking> Bookings { get; set; }

    public Guest()
    {
        
    }
}