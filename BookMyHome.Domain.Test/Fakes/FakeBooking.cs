using BookMyHome.Domain.Enitity;

namespace BookMyHome.Domain.Test.Fakes;

public class FakeBooking : Booking
{
    public FakeBooking(DateOnly startDate, DateOnly endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public new void AssureStartDateBeforeEndDate()
    {
        base.AssureStartDateBeforeEndDate();
    }

    public new void AssureBookingIsInTheFuture(DateOnly now)
    {
        base.AssureBookingIsInTheFuture(now);
    }

    public new void AssureBookingIsNotOverlapping(IEnumerable<Booking> otherBookings)
    {
        base.AssureBookingIsNotOverlapping(otherBookings);
    }

    
}