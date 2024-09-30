namespace BookMyHome.Application.Command.CommandDto;

public record CreateReviewDto
{
    public string Review { get; set; }
    public int BookingId { get; set; }
}