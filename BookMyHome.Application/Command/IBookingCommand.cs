using BookMyHome.Application.Command.CommandDto;

namespace BookMyHome.Application.Command;

public interface IBookingCommand
{
    void CreateBooking(CreateBookingDto bookingDto);
    void UpdateBooking(UpdateBookingDto bookingDto);
    void DeleteBooking(DeleteDto bookingDto);
}