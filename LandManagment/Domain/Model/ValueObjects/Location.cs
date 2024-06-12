namespace LandManagement.Domain.Model.ValueObjects
{
    public record Location(double Latitude, double Longitude, string Address, string City, string State, string PostalCode)
    {
        public Location() : this(0, 0, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        public Location(double latitude, double longitude) : this(latitude, longitude, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        public Location(string address, string city, string state, string postalCode) : this(0, 0, address, city, state, postalCode)
        {
        }

        public string FullLocation() => $"{Address}, {City}, {State}, {PostalCode}";



    }
}
