using BookMyHome.Domain.Enitity;

namespace BookMyHome.Domain.DomainServices;

public interface ICheckBooking
{
    public void AssureBookingIsNotOverlapping(Booking booking, IEnumerable<Booking> otherBookings);
}

public class CheckBooking : ICheckBooking
{
    public void AssureBookingIsNotOverlapping(Booking booking, IEnumerable<Booking> otherBookings)
    {

        foreach (var otherBooking in otherBookings)
        {
            if (booking.StartDate <= otherBooking.EndDate && otherBooking.StartDate <= booking.EndDate) // Der er mange senarier men dette dobbeltsenarie skal være gældende for overlap
            {
                throw new ArgumentException("Booking Overlapper med en eksisterende Booking");
            }
        }

    }
}