namespace BookMyHome.Application.Command.CommandDto;

public record DeleteDto : BaseDto
{
    public int Id { get; set; }
    public byte[] RowVersion { get; set; }
}