using BookMyHome.Domain.Enitity;

namespace BookMyHome.Application.Queries.QueriesDto;

public record AccommodationDto
{
    public int Id { get; set; }
    public byte[] RowVersion { get; set; } 
}