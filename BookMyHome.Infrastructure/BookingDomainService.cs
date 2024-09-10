using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Enitity;

namespace BookMyHome.Infrastructure;

public class BookingDomainService : IBookingDomainService
{
    private readonly BookMyHomeContext _db;
    public BookingDomainService(BookMyHomeContext db)
    {
        _db = db;
    }

    IEnumerable<Booking> IBookingDomainService.GetOtherBookings(Booking booking)
    {
        return _db.Bookings
            .Where(b => b.Id != booking.Id)
            .ToList();
    }
}