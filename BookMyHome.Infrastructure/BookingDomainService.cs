namespace BookMyHome.Infrastructure;

public class BookingDomainService
{
    private readonly BookMyHomeContext _db;
    public BookingDomainService(BookMyHomeContext db)
    {
        _db = db;
    }



}