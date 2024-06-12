using LandManagement.Domain.Model.Aggregates;

namespace LandManagement.Domain.Model.Queries;

public interface ILandQueryService
{
    Task<IEnumerable<Land>> Handle(GetAllLandsQuery query);
    Task<Land?> Handle(GetLandByIdQuery query);
}
