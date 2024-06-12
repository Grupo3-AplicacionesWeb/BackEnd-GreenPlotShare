using agro_shop.Shared.Domain.Repositories;
using LandManagement.Domain.Model.Aggregates;

namespace LandManagement.Domain.Repositories;

public interface ILandRepository : IBaseRepository<Land>
{
    Task<Land?> FindLandByIdAsync(int ownerId);
}
