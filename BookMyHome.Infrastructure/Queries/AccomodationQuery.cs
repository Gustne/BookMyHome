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

    IEnumerable<AccommodationDto> IAccomodationQuery.getAccommodations()
    {
        var result = _db.Accommodations.AsNoTracking().Select(a => new AccommodationDto
        {
            Id = a.Id,
            RowVersion = a.RowVersion,
        });
        return result;
    }

    IEnumerable<AccommodationDto> IAccomodationQuery.getAccommodations(int hostId)
    {
        var result = _db.Accommodations.AsNoTracking()
            .Where(a => a.Host.Id == hostId)
            .Select(a => new AccommodationDto
        {
            Id = a.Id,
            RowVersion = a.RowVersion,
        });
        return result;
    }


}