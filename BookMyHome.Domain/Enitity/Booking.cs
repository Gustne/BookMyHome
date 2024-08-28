using BookMyHome.Domain.DomainServices;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BookMyHome.Domain.Test")]

namespace BookMyHome.Domain.Enitity;


public class Booking
{
    public DateOnly StartDate { get; protected set; }
    public DateOnly EndDate { get; protected set; }

    internal static void AssureStartDateBeforeEndDate(DateOnly startDate, DateOnly endDate)
    {
        if (!(startDate < endDate))
        {
            throw new ArgumentException("StartDato skal være før Slutdato");
        }
    }
    internal static void AssureBookingIsInTheFuture(DateOnly startDate, DateOnly now)
    {
        if (startDate < now)
        {
            throw new ArgumentException("Booking skal være i fremtiden");
        }
    }

    public static Booking Create(DateOnly startDate, DateOnly endDate, ICheckBooking checkBooking, IEnumerable<Booking> otherBookings)
    {

        AssureStartDateBeforeEndDate(startDate, endDate);


        AssureBookingIsInTheFuture(startDate, DateOnly.FromDateTime(DateTime.Now));

        var booking = new Booking
        {
            StartDate = startDate,
            EndDate = endDate
        };

        // Booking må ikke overlappe med en anden booking
        checkBooking.AssureBookingIsNotOverlapping(booking, otherBookings);

        return booking;
    }
}