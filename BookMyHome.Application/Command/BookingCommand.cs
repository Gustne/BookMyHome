using BookMyHome.Application.Command.CommandDto;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Enitity;

namespace BookMyHome.Application.Command;

public class BookingCommand : IBookingCommand
{
    private readonly IBookingRepository _repository;
    private readonly IBookingDomainService _domainService;

    public BookingCommand(IBookingRepository repository, IBookingDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    void IBookingCommand.CreateBooking(CreateBookingDto BookingDto)
    {
        var booking = Booking.Create(BookingDto.StartDate, BookingDto.EndDate, _domainService);

        _repository.AddBooking(booking);
    }

    void IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto, byte[] rowVersion)
    {
        //Load
        var booking = _repository.GetBooking(updateBookingDto.Id);
        //Do
        booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, _domainService);
        //Save
        _repository.UpdateBooking(booking, updateBookingDto.RowVersion);
    }

    public void DeleteBooking(DeleteBookingDto bookingDto)
    {
        throw new NotImplementedException();
    }
}