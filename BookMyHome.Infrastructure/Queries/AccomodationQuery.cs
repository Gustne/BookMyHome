using BookMyHome.Application.Queries;
using BookMyHome.Application.Queries.QueriesDto;
using BookMyHome.Domain.Enitity;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Queries;

public class AccomodationQuery : IAccomodationQuery
{
    private readonly BookMyHomeContext _db;

    public AccomodationQuery(BookMyHomeContext db)
    {
        _db = db;
    }

    AccommodationDto IAccomodationQuery.GetAccomodation(int id)
    {
        var accommodation = _db.Accommodations.AsNoTracking().Single(a => a.Id == id);
        return new AccommodationDto
        {
            Id = accommodation.Id,
            RowVersion = accommodation.RowVersion,
        };
    }

    IEnumerable<AccommodationDto> IAccomodationQuery.getAccommodations(int hostId)
    {
        var result = _db.Accommodations.AsNoTracking()
            .Where(a => a.Host.Id == hostId)
            .Include(a => a.Bookings)
            .Select(a => new AccommodationDto
        {
            Id = a.Id,
            RowVersion = a.RowVersion,

            Bookings = a.Bookings.Select(b => new BookingDto
            {
                StartDate = b.StartDate
                , EndDate = b.EndDate
            }).ToList()
        });
        return result;
    }

    IEnumerable<AccommodationDto> IAccomodationQuery.getAccommodationsWithFeedback(int hostId)
    {
        var result = _db.Accommodations
            .AsNoTracking()
            .Where(a => a.Host.Id == hostId)
            .Include(a => a.Bookings) 
            .ThenInclude(b => b.Rating) 
            .Include(a => a.Bookings) 
            .ThenInclude(b => b.Review) 
            .Select(a => new AccommodationDto
            {
                Id = a.Id,
                RowVersion = a.RowVersion,
                Ratings = a.Bookings.Where(b => b.Rating != null)
                    .Select(b => new RatingDto
                    {
                        Score = b.Rating.Score
                    }).ToList(),
                Reviews = a.Bookings.Where(b => b.Review != null)
                    .Select(b => new ReviewDto
                    {
                        Content = b.Review.ReviewString
                    }).ToList()
            });
        return result;
    }


}