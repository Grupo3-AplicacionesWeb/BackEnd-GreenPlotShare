using LandManagement.Domain.Model.Commands;
using LandManagement.Domain.Model.ValueObjects;

namespace LandManagement.Domain.Model.Aggregates;

public partial class Land
{
    public Land()
    {
        Name=string.Empty;
        Description=string.Empty;
        Features = new Feature();
        Location = new Location();
        Price = new Price();
    }

    public Land(string name, string description, double size, string soilType, string irrigation, decimal amount, string currency, double latitude, double longitude, string address, string city, string state, string postalCode)
    {
        Name = name;
        Description = description;
        Features = new Feature(size, soilType, irrigation);
        Price = new Price(amount, currency);
        Location = new Location(latitude, longitude, address, city, state, postalCode);
    }

    public Land(CreateLandCommand command){
        Name = command.Name;
        Description = command.Description;
        Features = new Feature(command.Size, command.SoilType, command.Irrigation);
        Price = new Price(command.Amount, command.Currency);
        Location = new Location(command.Latitude, command.Longitude, command.Address, command.City, command.State, command.PostalCode);
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Location Location { get; set; }
    public Feature Features { get; set; }
    public Price Price { get; set; }

    public string FullLocation=> Location.FullLocation();
    public string FullFeature => Features.FullFeature();
    public string FullPrice => Price.FullPrice();
}
