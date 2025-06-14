using AutoService.Shared.Models;
using GarageService.Api.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/assemblies")]
public class AssembliesController : ControllerBase
{
    private readonly AssemblyService _assemblyService;

    public AssembliesController(AssemblyService assemblyService)
    {
        _assemblyService = assemblyService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Assembly>> GetAll()
    {
        return Ok(_assemblyService.GetAllAssemblys());
    }

    [HttpGet("{id}")]
    public ActionResult<Assembly> GetById(int id)
    {
        var assembly = _assemblyService.GetById(id);
        if (assembly == null)
        {
            return NotFound();
        }
        return Ok(assembly);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<Assembly>> Search([FromQuery] string query)
    {
        return Ok(_assemblyService.SearchAssemblys(query));
    }

    [HttpPost]
    public IActionResult Create([FromBody] Assembly assembly)
    {
        if (assembly == null)
        {
            return BadRequest();
        }
        _assemblyService.AddAssembly(assembly);
        return CreatedAtAction(nameof(GetById), new { id = assembly.IdAssembly }, assembly);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Assembly assembly)
    {
        if (id != assembly.IdAssembly)
        {
            return BadRequest();
        }
        _assemblyService.UpdateAssembly(assembly);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _assemblyService.DeleteAssembly(id);
        return NoContent();
    }
}