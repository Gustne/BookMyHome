using BookMyHome.Application.Queries.QueriesDto;

namespace BookMyHome.Application.Queries;

public interface IAccomodationQuery
{
    AccommodationDto GetAccomodation(int id);
    IEnumerable<AccommodationDto> getAccommodations(int hostId);

    IEnumerable<AccommodationDto> getAccommodationsWithFeedback(int hostId);
}