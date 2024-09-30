using BookMyHome.Application.Command.CommandDto;
using BookMyHome.Application.Helpers;
using BookMyHome.Domain.Enitity;

namespace BookMyHome.Application.Command;

public class ReviewCommand : IReviewCommand
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewCommand(IBookingRepository bookingRepository, IUnitOfWork unitOfWork)
    {
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
    }

    void IReviewCommand.CreateReview(CreateReviewDto reviewDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            //Load
            var booking = _bookingRepository.GetBookingWithFeedback(reviewDto.BookingId);

            if (booking.Review == null)
            {
                var review = Review.Create(reviewDto.Review);
                booking.AddReview(review);

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