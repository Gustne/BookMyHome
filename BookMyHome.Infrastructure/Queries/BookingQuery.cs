using BookMyHome.Application.Queries;
using BookMyHome.Application.Queries.QueriesDto;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Queries;

public class BookingQuery : IBookingQuery
{
    private readonly BookMyHomeContext _db;
    public BookingQuery(BookMyHomeContext db)
    {
        _db = db;
    }

    BookingDto IBookingQuery.getBooking(int id)
    {
        var booking = _db.Bookings.AsNoTracking().Single(a => a.Id == id);
        return new BookingDto
        {
            id = booking.Id,
            StartDate = booking.StartDate,
            EndDate = booking.EndDate,
            RowVersion = booking.RowVersion
        };
    }

    IEnumerable<BookingDto> IBookingQuery.GetBookings()
    {
        var result = _db.Bookings.AsNoTracking().Select(b => new BookingDto
        {
            id = b.Id,
            StartDate = b.StartDate,
            EndDate = b.EndDate
        });
        return result;
    }
}