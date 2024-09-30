using BookMyHome.Domain.Enitity;

namespace BookMyHome.Application.Queries.QueriesDto;

public record AccommodationDto
{
    public int Id { get; set; }
    public byte[] RowVersion { get; set; } 
    
    public IEnumerable<BookingDto> Bookings { get; set; }

    public IEnumerable<ReviewDto> Reviews {get; set;}
    public IEnumerable<RatingDto> Ratings {get; set;}
}