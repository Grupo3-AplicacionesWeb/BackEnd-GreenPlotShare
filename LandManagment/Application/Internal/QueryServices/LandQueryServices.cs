using LandManagement.Domain.Model.Aggregates;
using LandManagement.Domain.Model.Queries;
using LandManagement.Domain.Repositories;

namespace LandManagement.Application.Internal.QueryServices;

public class LandQueryService(ILandRepository landRepository) : ILandQueryService
{
    public async Task<IEnumerable<Land>> Handle(GetAllLandsQuery query)
    {
        return await landRepository.ListAsync();
    }

    public async Task<Land?> Handle(GetLandByIdQuery query)
    {
        return await landRepository.FindLandByIdAsync(query.LandId);
    }

}
