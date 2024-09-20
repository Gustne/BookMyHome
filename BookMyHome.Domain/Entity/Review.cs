namespace BookMyHome.Domain.Enitity;

public class Review : DomainEntity
{
    public string ReviewString { get; protected set; }

    public Review(string reviewString, Booking booking)
    {
        DateOnly todayDate = DateOnly.FromDateTime(DateTime.Now);
        EnsureBookingIsOver(todayDate,booking);
        ReviewString = reviewString;
    }


    public static Review Create(string reviewString, Booking booking)
    {
        return new Review(reviewString, booking);
    }

    public void Update(string reviewString, Booking booking)
    {
        DateOnly todayDate = DateOnly.FromDateTime(DateTime.Now);
        EnsureBookingIsOver(todayDate, booking);
        ReviewString = ReviewString;
    }

    private void EnsureBookingIsOver(DateOnly Now, Booking booking)
    {
        if (booking.EndDate < Now)
        {
            throw new ArgumentException($"Din booking skal være slut før du kan give {nameof(Review).ToLower()}");
        }
    }
}