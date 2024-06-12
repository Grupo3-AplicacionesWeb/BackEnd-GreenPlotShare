using LandManagement.Domain.Model.Commands;
using LandManagement.Interfaces.REST.Resources;

namespace LandManagement.Interfaces.REST.Transform;

public static class CreateLandCommandFromResourceAssembler
{
       public static CreateLandCommand ToCommandFromResource(CreateLandResource resource)
    {
        return new CreateLandCommand(resource.Name, resource.Description, resource.Size, resource.SoilType, resource.Irrigation, resource.Latitude, resource.Longitude, resource.Address, resource.City, resource.State, resource.PostalCode, resource.Amount, resource.Currency);
    }
}
