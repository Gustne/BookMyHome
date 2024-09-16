using System.Runtime.CompilerServices;
using BookMyHome.Domain.Enitity;

namespace BookMyHome.Application;

public interface IAccommodationRepository
{
    Accommodation GetAccommodation(int id);
    void CreateAccommodation(Accommodation accommodation);
    void UpdateAccommodation(Accommodation accommodation, byte[] rowVersion);
    void DeleteAccommodation(Accommodation accommodation, byte[] rowVersion);
}