using System.Data;
using BookMyHome.Application.Command.CommandDto;
using BookMyHome.Application.Helpers;
using BookMyHome.Domain.Enitity;

namespace BookMyHome.Application.Command;

public class BookingCommand : IBookingCommand
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IAccommodationRepository _accommodationRepository;
    private readonly IGuestRepository _guestRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BookingCommand(IBookingRepository repository, IAccommodationRepository accommodationRepository, IGuestRepository guestRepository, IUnitOfWork unitOfWork)
    {
        _bookingRepository = repository;
        _accommodationRepository = accommodationRepository;
        _guestRepository = guestRepository;
        _unitOfWork = unitOfWork;
    }

    void IBookingCommand.CreateBooking(CreateBookingDto bookingDto)
    {

        try
        {
            _unitOfWork.BeginTransaction();
            //load
            var accommodation = _accommodationRepository.GetAccommodationWithBookinngs(bookingDto.AccommodationId);
            var guest = _guestRepository.GetGuest(bookingDto.GuestId);
            var booking = Booking.Create(bookingDto.StartDate, bookingDto.EndDate, accommodation, guest);

            _bookingRepository.AddBooking(booking);

            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }



    }

    void IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        

        try
        {
            _unitOfWork.BeginTransaction();
            //load
            var booking = _bookingRepository.GetBooking(updateBookingDto.Id);
            if (booking == null)
            {
                throw new KeyNotFoundException($"Booking with id:{updateBookingDto.Id} not found");
            }

            var accommodation = _accommodationRepository.GetAccommodationWithBookinngs(booking.Id);
                

            //Update
            booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, accommodation);
            //Save
            _bookingRepository.UpdateBooking(booking, updateBookingDto.RowVersion);
            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }

    }

    public void DeleteBooking(DeleteBookingDto deleteBookingDto)
    {
        

        try
        {
            _unitOfWork.BeginTransaction();
            //load
            var booking = _bookingRepository.GetBooking(deleteBookingDto.Id);
            if (booking == null)
            {
                throw new KeyNotFoundException($"Booking with id:{deleteBookingDto.Id} not found");
            }
            //Update
            
            //Save
            _bookingRepository.DeleteBooking(booking, deleteBookingDto.RowVersion);
            _unitOfWork.Commit();
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }
}