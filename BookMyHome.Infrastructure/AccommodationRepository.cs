using BookMyHome.Application;
using BookMyHome.Domain.Enitity;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure;

public class AccommodationRepository : IAccommodationRepository
{
    private readonly BookMyHomeContext _db;

    public AccommodationRepository(BookMyHomeContext db)
    {
        _db = db;
    } 

    void IAccommodationRepository.CreateAccommodation(Accommodation accommodation)
    {
        _db.Accommodations.Add(accommodation);
    }
    Accommodation IAccommodationRepository.GetAccommodation(int id)
    {
        return _db.Accommodations.Single(a => a.Id == id);
    }
    Accommodation IAccommodationRepository.getAccommodationWithBookinngs(int id)
    {
        return _db.Accommodations.Include(a => a.Bookings).Single(a => a.Id == id);
    }
    void IAccommodationRepository.UpdateAccommodation(Accommodation accommodation, byte[] rowVersion)
    {
        _db.Entry(accommodation).Property(nameof(accommodation.RowVersion)).OriginalValue = rowVersion;
    }

    void IAccommodationRepository.DeleteAccommodation(Accommodation accommodation, byte[] rowVersion)
    {
        _db.Entry(accommodation).Property(nameof(accommodation.RowVersion)).OriginalValue = rowVersion;
        _db.Accommodations.Remove(accommodation);
    }


}