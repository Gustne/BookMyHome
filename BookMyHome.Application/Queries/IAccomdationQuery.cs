using BookMyHome.Application.Queries.QueriesDto;

namespace BookMyHome.Application.Queries;

public interface IAccomodationQuery
{
    AccomodationDto GetAccomodation(int id);
    IEnumerable<AccomodationDto> getAccomodations(int HostId);
}