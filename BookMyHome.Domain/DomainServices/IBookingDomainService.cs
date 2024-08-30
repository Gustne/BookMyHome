using BookMyHome.Domain.Enitity;

namespace BookMyHome.Domain.DomainServices;

public interface IBookingDomainService
{
    public IEnumerable<Booking> GetOtherBookings(Booking booking);

}

public class BookingDomainService : IBookingDomainService
{
    public IEnumerable<Booking> GetOtherBookings(Booking booking)
    {
        throw new NotImplementedException();
    }
}

