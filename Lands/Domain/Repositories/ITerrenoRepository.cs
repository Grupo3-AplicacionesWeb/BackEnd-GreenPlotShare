using agro_shop.Lands.Domain.Model.Aggregates;
using agro_shop.Shared.Domain.Repositories;

namespace agro_shop.Lands.Domain.Repositories;

public interface ITerrenoRepository : IBaseRepository<Terreno>
{
    Task<Terreno?> FindTerrenoByNombreAsync(string Nombre);
    Task AddAsync(Terreno terreno);
    Task UpdateAsync(Terreno terreno);
    Task DeleteAsync(Guid id);
    Task<Terreno> GetByIdAsync(Guid id);
    Task<IEnumerable<Terreno>> GetAllAsync();
}