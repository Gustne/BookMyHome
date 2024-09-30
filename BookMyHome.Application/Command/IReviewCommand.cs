using BookMyHome.Application.Command.CommandDto;

namespace BookMyHome.Application.Command;

public interface IReviewCommand
{
    void CreateReview(CreateReviewDto reviewDto);
}