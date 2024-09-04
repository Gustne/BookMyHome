using BookMyHome.Application.Queries.QueriesDto;

namespace BookMyHome.Application.Queries;

public interface IBookingQuery
{
    BookingDto getBooking(int id);
    IEnumerable<BookingDto> GetBookings();
}