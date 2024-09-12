using BookMyHome.Application.Queries.QueriesDto;

namespace BookMyHome.Application.Queries;

public interface IAccomodationQuery
{
    AccommodationDto GetAccomodation(int id);
    IEnumerable<AccommodationDto> getAccommodations();

    IEnumerable<AccommodationDto> getAccommodations(int HostId);
}