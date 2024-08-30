using BookMyHome.Domain.Enitity;

namespace BookMyHome.Application;

public interface IBookingRepository
{
    Booking GetBooking(int id); 
    void AddBooking(Booking booking);
}
