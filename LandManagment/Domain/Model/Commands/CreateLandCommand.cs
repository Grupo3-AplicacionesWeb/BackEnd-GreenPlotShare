namespace LandManagement.Domain.Model.Commands
{
    public record CreateLandCommand(string Name, string Description, double Size, string SoilType, string Irrigation, double Latitude, double Longitude, string Address, string City, string State, string PostalCode, decimal Amount, string Currency);
}
