namespace BookMyHome.Application.Command.CommandDto;

public record UpdateRatingDto : BaseDto
{ public int Rating { get; set; }
}