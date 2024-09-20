using System.Diagnostics.CodeAnalysis;

namespace BookMyHome.Domain.Enitity;

public class Rating : DomainEntity
{
    
    public int Score { get; protected set; }

    public Rating(int score, Booking booking)
    {
        DateOnly todayDate = DateOnly.FromDateTime(DateTime.Now);
        EnsureBookingIsOver(todayDate, booking);
        Score = score;
    }

    public static Rating Create(int score, Booking booking)
    {

        return new Rating(score, booking);
    }


    public void Update(int score, Booking booking)
    {
        DateOnly todayDate = DateOnly.FromDateTime(DateTime.Now);
        EnsureBookingIsOver(todayDate, booking);
        Score = score;
    }


    private void EnsureBookingIsOver(DateOnly Now, Booking booking)
    {
        if (booking.EndDate < Now)
        {
            throw new ArgumentException($"Din booking skal være slut før du kan give {nameof(Rating).ToLower()}");
        }
    }

}