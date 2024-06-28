using agro_shop.Lands.Domain.Model.Aggregates;
using agro_shop.Lands.Domain.Repositories;
using agro_shop.Lands.Domain.Services;

namespace agro_shop.Lands.Application.Internal.CommandServices;

public class TerrenoService : ITerrenoService
{
    private readonly ITerrenoRepository _terrenoRepository;

    public TerrenoService(ITerrenoRepository terrenoRepository)
    {
        _terrenoRepository = terrenoRepository;
    }

    public async Task<Terreno> GetTerrenoByIdAsync(Guid id)
    {
        return await _terrenoRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Terreno>> GetAllTerrenosAsync()
    {
        return await _terrenoRepository.GetAllAsync();
    }

    public async Task CreateTerrenoAsync(Terreno terreno)
    {
        terreno.Id = Guid.NewGuid(); 
        await _terrenoRepository.AddAsync(terreno);
    }

    public async Task UpdateTerrenoAsync(Terreno terreno)
    {
        await _terrenoRepository.UpdateAsync(terreno);
    }

    public async Task DeleteTerrenoAsync(Guid id)
    {
        await _terrenoRepository.DeleteAsync(id);
    }

    public async Task<Terreno?> FindTerrenoByNombreAsync(string nombre)
    {
        return await _terrenoRepository.FindTerrenoByNombreAsync(nombre);
    }
}