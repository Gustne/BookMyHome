namespace BookMyHome.Application.Command.CommandDto;

public record CreateRatingDto
{
    public int Score { get; set; }
    public int BookingId { get; set; }
}