namespace BookMyHome.Application.Command.CommandDto;

public abstract record BaseDto
{
    public int Id { get; set; }
    public byte[] RowVersion { get; set; }

}
