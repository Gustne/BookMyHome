using System.Data;
using BookMyHome.Application.Command.CommandDto;
using BookMyHome.Application.Helpers;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Enitity;

namespace BookMyHome.Application.Command;

public class BookingCommand : IBookingCommand
{
    private readonly IBookingRepository _repository;
    private readonly IBookingDomainService _domainService;
    private readonly IUnitOfWork _unitOfWork;

    public BookingCommand(IBookingRepository repository, IBookingDomainService domainService, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _domainService = domainService;
        _unitOfWork = unitOfWork;
    }

    void IBookingCommand.CreateBooking(CreateBookingDto BookingDto)
    {
        _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

        try
        {
            var booking = Booking.Create(BookingDto.StartDate, BookingDto.EndDate, _domainService);

            _repository.AddBooking(booking);

            _unitOfWork.Commit();
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw e;
        }



    }

    void IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

        try
        {
            //load
            var booking = _repository.GetBooking(updateBookingDto.Id);
            if (booking == null)
            {
                throw new KeyNotFoundException($"Booking with id:{updateBookingDto.Id} not found");
            }
            //Update
            booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, _domainService);
            //Save
            _repository.UpdateBooking(booking, updateBookingDto.RowVersion);
            _unitOfWork.Commit();
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw e;
        }

    }

    public void DeleteBooking(int id, DeleteBookingDto deleteBookingDto)
    {
        _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

        try
        {
            //load
            var booking = _repository.GetBooking(id);
            if (booking == null)
            {
                throw new KeyNotFoundException($"Booking with id:{id} not found");
            }
            //Update
            
            //Save
            _repository.DeleteBooking(booking, deleteBookingDto.RowVersion);
            _unitOfWork.Commit();
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw e;
        }
    }
}