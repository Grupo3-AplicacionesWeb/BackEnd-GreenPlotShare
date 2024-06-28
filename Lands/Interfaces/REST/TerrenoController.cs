using agro_shop.Lands.Domain.Model.Aggregates;
using agro_shop.Lands.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace agro_shop.Lands.Interfaces.REST;
[ApiController]
[Route("api/[controller]")]
public class TerrenoController : ControllerBase
{
    private readonly ITerrenoService _terrenoService;

    public TerrenoController(ITerrenoService terrenoService)
    {
        _terrenoService = terrenoService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTerreno([FromBody] Terreno terreno)
    {
        await _terrenoService.CreateTerrenoAsync(terreno);
        return CreatedAtAction(nameof(GetTerrenoById), new { id = terreno.Id }, terreno);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTerrenos()
    {
        var terrenos = await _terrenoService.GetAllTerrenosAsync();
        return Ok(terrenos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTerrenoById([FromRoute] Guid id)
    {
        var terreno = await _terrenoService.GetTerrenoByIdAsync(id);
        if (terreno == null) return NotFound();
        return Ok(terreno);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTerreno([FromRoute] Guid id, [FromBody] Terreno terreno)
    {
        if (id != terreno.Id) return BadRequest();
        await _terrenoService.UpdateTerrenoAsync(terreno);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTerreno([FromRoute] Guid id)
    {
        await _terrenoService.DeleteTerrenoAsync(id);
        return NoContent();
    }

    [HttpGet("findByName/{nombre}")]
    public async Task<IActionResult> FindTerrenoByNombre([FromRoute] string nombre)
    {
        var terreno = await _terrenoService.FindTerrenoByNombreAsync(nombre);
        if (terreno == null) return NotFound();
        return Ok(terreno);
    }
}