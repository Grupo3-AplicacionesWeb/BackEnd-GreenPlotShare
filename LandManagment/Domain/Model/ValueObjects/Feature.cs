namespace LandManagement.Domain.Model.ValueObjects
{
    public record Feature(double Size, string SoilType, string Irrigation)
    {
        public Feature() : this(0, string.Empty, string.Empty)
        {
        }

        public Feature(double size) : this(size, string.Empty, string.Empty)
        {
        }

        public Feature(string soilType, string irrigation) : this(0, soilType, irrigation)
        {
        }

        public string FullFeature() => $"Size: {Size}, Soil Type: {SoilType}, Irrigation: {Irrigation}";
    }
}
