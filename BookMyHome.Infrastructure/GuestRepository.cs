using BookMyHome.Application;
using BookMyHome.Domain.Enitity;

namespace BookMyHome.Infrastructure;

public class GuestRepository : IGuestRepository
{
    private readonly BookMyHomeContext _db;
    public GuestRepository(BookMyHomeContext context)
    {
        _db = context;
    }

    Guest IGuestRepository.GetGuest(int id)
    {
        return _db.Guests.Single(g => g.Id == id);
    }

    void IGuestRepository.AddGuest(Guest guest)
    {
        throw new NotImplementedException();
    }

    void IGuestRepository.DeleteGuest(Guest guest, byte[] rowVersion)
    {
        throw new NotImplementedException();
    }

    void IGuestRepository.UpdateGuest(Guest guest, byte[] rowVersion)
    {
        throw new NotImplementedException();
    }
}