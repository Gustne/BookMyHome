using BookMyHome.Domain.Enitity;

namespace BookMyHome.Application.Queries.QueriesDto;

public record AccomodationDto
{
    public int HostId { get; set; }
    public Host host { get; set; }
}