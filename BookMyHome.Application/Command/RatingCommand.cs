using BookMyHome.Application.Command.CommandDto;
using BookMyHome.Application.Helpers;
using BookMyHome.Domain.Enitity;

namespace BookMyHome.Application.Command;

public class RatingCommand : IRatingCommand
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RatingCommand(IBookingRepository bookingRepository, IUnitOfWork unitOfWork)
    {
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
    }
    void IRatingCommand.CreateRating(CreateRatingDto ratingDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            //Load
            var booking = _bookingRepository.GetBookingWithFeedback(ratingDto.BookingId);

            if (booking.Rating == null)
            {
                var rating = Rating.Create(ratingDto.Score);
                booking.AddRating(rating);

            }
            else
            {
                throw new ArgumentException("Der er allerede en Rating");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

}