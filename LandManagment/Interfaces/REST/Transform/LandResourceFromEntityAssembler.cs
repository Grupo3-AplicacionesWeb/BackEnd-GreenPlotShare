using LandManagement.Domain.Model.Aggregates;
using LandManagement.Interface.REST.Resources;

namespace LandManagement.Interfaces.REST.Transform;

public static class LandResourceFromEntityAssembler
{
    public static LandResource ToResourceFromEntity(Land entity)
    {
        return new LandResource(entity.Id, entity.Name, entity.Description);
    }
}
