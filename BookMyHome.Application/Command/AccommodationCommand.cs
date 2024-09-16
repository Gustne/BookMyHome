using BookMyHome.Application.Command.CommandDto;
using BookMyHome.Application.Helpers;
using BookMyHome.Domain.Enitity;

namespace BookMyHome.Application.Command;

public class AccommodationCommand : IAccommodationCommand
{
    private readonly IAccommodationRepository _accommodationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHostRepository _hostRepository;

    public AccommodationCommand(IAccommodationRepository accommodationRepository, IUnitOfWork unitOfWork, IHostRepository hostRepository)
    {
        _accommodationRepository = accommodationRepository;
        _unitOfWork = unitOfWork;
        _hostRepository = hostRepository;
    }
    void IAccommodationCommand.CreateAccommodation(CreateAccommodationDto accommodationDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var host = _hostRepository.GetHost(accommodationDto.HostId);
            var accommodation = Accommodation.Create(host);
            _accommodationRepository.CreateAccommodation(accommodation);
            _unitOfWork.Commit();
            
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }


        
    }
    void IAccommodationCommand.UpdateAccommodation(UpdateAccommodationDto accommodationDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            //load
            var accommodation = _accommodationRepository.GetAccommodation(accommodationDto.Id);
            if (accommodation == null)
            {
                throw new KeyNotFoundException($"Accommodation with id:{accommodationDto.Id} not found");
            }
            //Update meget uneventfull XD
            accommodation.Update();

            //save

            _accommodationRepository.UpdateAccommodation(accommodation, accommodationDto.RowVersion);
            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    void IAccommodationCommand.DeleteAccommodation(DeleteAccommodtationDto accommodationDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            //load
            var accommodation = _accommodationRepository.GetAccommodation(accommodationDto.Id);
            if (accommodation == null)
            {
                throw new KeyNotFoundException($"Accomodation with id{accommodationDto.Id} not found");
            }
            //Update
            _accommodationRepository.DeleteAccommodation(accommodation, accommodationDto.RowVersion);
            //save
            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }


}