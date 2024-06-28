using agro_shop.Lands.Domain.Model.Aggregates;

namespace agro_shop.Lands.Domain.Services;

public interface ITerrenoService
{
    Task<Terreno> GetTerrenoByIdAsync(Guid id);
    Task<IEnumerable<Terreno>> GetAllTerrenosAsync();
    Task CreateTerrenoAsync(Terreno terreno);
    Task UpdateTerrenoAsync(Terreno terreno);
    Task DeleteTerrenoAsync(Guid id);
    Task<Terreno?> FindTerrenoByNombreAsync(string nombre);
}