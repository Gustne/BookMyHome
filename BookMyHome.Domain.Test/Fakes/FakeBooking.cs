using BookMyHome.Domain.Enitity;

namespace BookMyHome.Domain.Test.Fakes;

public class FakeBooking : Booking
{
    public FakeBooking(DateOnly startDate, DateOnly endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }
}