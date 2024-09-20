namespace BookMyHome.Application.Command.CommandDto;

public record UpdateBookingDto : BaseDto
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}