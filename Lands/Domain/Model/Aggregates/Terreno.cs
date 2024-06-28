namespace agro_shop.Lands.Domain.Model.Aggregates;

public class Terreno
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public double Area { get; set; }
    public string Ubicacion { get; set; }
}