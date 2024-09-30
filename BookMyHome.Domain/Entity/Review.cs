namespace BookMyHome.Domain.Enitity;

public class Review : DomainEntity
{
    public string ReviewString { get; protected set; }

    public Review(string reviewString)
    {

        ReviewString = reviewString;
    }


    public static Review Create(string reviewString)
    {
        return new Review(reviewString);
    }

    public void Update(string reviewString)
    {

        ReviewString = ReviewString;
    }


}