using BookMyHome.Application.Queries.QueriesDto;

namespace BookMyHome.Application.Queries;

public interface IBookingQuery
{
    BookingDto GetBooking(int id);
    IEnumerable<BookingDto> GetBookings();
}