using BookMyHome.Application.Queries;
using BookMyHome.Application.Queries.QueriesDto;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Queries;

public class AccomodationQuery : IAccomodationQuery
{
    private readonly BookMyHomeContext _db;

    public AccomodationQuery(BookMyHomeContext db)
    {
        _db = db;
    }

    AccomodationDto IAccomodationQuery.GetAccomodation(int id)
    {
        throw new NotImplementedException();
    }

    IEnumerable<AccomodationDto> IAccomodationQuery.getAccomodations(int HostId)
    {
        
        throw new NotImplementedException();
    }
}