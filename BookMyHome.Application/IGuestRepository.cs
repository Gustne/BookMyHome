using BookMyHome.Domain.Enitity;

namespace BookMyHome.Application;

public interface IGuestRepository
{
    Guest GetGuest(int id);
    void AddGuest(Guest guest);
    void UpdateGuest(Guest guest, byte[] rowVersion);
    void DeleteGuest(Guest guest, byte[] rowVersion);
}