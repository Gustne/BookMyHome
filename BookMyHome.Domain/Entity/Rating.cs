using System.Diagnostics.CodeAnalysis;

namespace BookMyHome.Domain.Enitity;

public class Rating : DomainEntity
{
    
    public int Score { get; protected set; }
    public Booking Booking { get; protected set; }

    public Rating(int score)
    {
        Score = score;
    }

    public static Rating Create(int score)
    {
        return new Rating(score);
    }


    public void Update(int score)
    {
        Score = score;
    }


}