using agro_shop.Shared.Domain.Repositories;
using LandManagement.Domain.Model.Aggregates;
using LandManagement.Domain.Model.Commands;
using LandManagement.Domain.Repositories;
using LandManagement.Domain.Services;

namespace LandManagement.Application.Internal.CommandServices;

public class LandCommandService(ILandRepository landRepository, IUnitOfWork unitOfWork)  : ILandCommandService
{
    public async Task<Land?> Handle(CreateLandCommand command)
    {
        var land = new Land(command);
        try
        {
            await landRepository.AddAsync(land);
            await unitOfWork.CompleteAsync();
            return land;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the land: {e.Message}");
            return null;
        }
    }
}
