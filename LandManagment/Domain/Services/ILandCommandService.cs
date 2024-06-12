using LandManagement.Domain.Model.Aggregates;
using LandManagement.Domain.Model.Commands;

namespace LandManagement.Domain.Services
{
    public interface ILandCommandService
    {
        Task<Land?> Handle(CreateLandCommand command);

    }
}
