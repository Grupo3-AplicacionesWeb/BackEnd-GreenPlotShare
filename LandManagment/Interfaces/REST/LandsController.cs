using System.Net.Mime;
using LandManagement.Domain.Model.Queries;
using LandManagement.Domain.Services;
using LandManagement.Interfaces.REST.Resources;
using LandManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace LandManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class LandsController(ILandCommandService landCommandService, ILandQueryService landQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLand(CreateLandResource resource)
    {
        var createLandCommand = CreateLandCommandFromResourceAssembler.ToCommandFromResource(resource);
        var land = await landCommandService.Handle(createLandCommand);
        if (land is null) return BadRequest();
        var landResource = LandResourceFromEntityAssembler.ToResourceFromEntity(land);
        return CreatedAtAction(nameof(GetLandById), new {landId = landResource.Id}, landResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLands()
    {
        var getAllLandQuery = new GetAllLandsQuery();
        var lands = await landQueryService.Handle(getAllLandQuery);
        var landResources = lands.Select(LandResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(landResources);
    }

    [HttpGet("{landId:int}")]
    public async Task<IActionResult> GetLandById(int landId)
    {
        var getLandByIdQuery = new GetLandByIdQuery(landId);
        var land = await landQueryService.Handle(getLandByIdQuery);
        if (land == null) return NotFound();
        var landResource = LandResourceFromEntityAssembler.ToResourceFromEntity(land);
        return Ok(landResource);
    }
}
