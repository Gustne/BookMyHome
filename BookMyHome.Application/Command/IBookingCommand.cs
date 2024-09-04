using BookMyHome.Application.Command.CommandDto;

namespace BookMyHome.Application.Command;

public interface IBookingCommand
{
    void CreateBooking(CreateBookingDto bookingDto);
    void UpdateBooking(UpdateBookingDto bookingDto, byte[] rowVersion);
    void DeleteBooking(DeleteBookingDto bookingDto);
}