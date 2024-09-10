using BookMyHome.Application;
using BookMyHome.Domain.Enitity;

namespace BookMyHome.Infrastructure;

public class BookingRepository : IBookingRepository
{
    private readonly BookMyHomeContext _db;
    public BookingRepository(BookMyHomeContext context)
    {
        _db = context;  
    }
    void IBookingRepository.AddBooking(Booking booking)
    {
        _db.Bookings.Add(booking);
    }



    Booking IBookingRepository.GetBooking(int id)
    {
        return _db.Bookings.Single(b => b.Id == id);
    }

    void IBookingRepository.UpdateBooking(Booking booking, byte[] rowVersion)
    {
        _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowVersion;
    }

    void IBookingRepository.DeleteBooking(Booking booking, byte[] rowVersion)
    {
        _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowVersion;
        _db.Bookings.Remove(booking);
    }
}