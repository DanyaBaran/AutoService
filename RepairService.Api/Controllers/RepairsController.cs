using AutoService.Shared.Models;
using RepairService.Api.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/repairs")]
public class RepairsController : ControllerBase
{
    private readonly RepairsService _repairService;

    public RepairsController(RepairsService repairService)
    {
        _repairService = repairService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Repair>> GetAll()
    {
        return Ok(_repairService.GetAllRepairs());
    }

    [HttpGet("{id}")]
    public ActionResult<Repair> GetById(int id)
    {
        var repair = _repairService.GetById(id);
        if (repair == null)
        {
            return NotFound();
        }
        return Ok(repair);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<Repair>> Search([FromQuery] string query)
    {
        return Ok(_repairService.SearchRepairs(query));
    }

    [HttpPost]
    public IActionResult Create([FromBody] Repair repair)
    {
        if (repair == null)
        {
            return BadRequest("Repair object is null");
        }
        _repairService.AddRepair(repair);
        return CreatedAtAction(nameof(GetById), new { id = repair.IdRepair }, repair);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Repair repair)
    {
        if (id != repair.IdRepair)
        {
            return BadRequest("ID in URL does not match ID in body");
        }
        _repairService.UpdateRepair(repair);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repairService.DeleteRepair(id);
        return NoContent();
    }
}