using BookMyHome.Application.Command.CommandDto;

namespace BookMyHome.Application.Command;

public interface IAccommodationCommand
{
    void CreateAccommodation(CreateAccommodationDto accommodationDto);
    void UpdateAccommodation(UpdateAccommodationDto accommodationDto);
    void DeleteAccommodation(DeleteDto accommodationDto);
}