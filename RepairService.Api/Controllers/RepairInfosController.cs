using AutoService.Shared.Models;
using RepairService.Api.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/repairinfos")]
public class RepairInfosController : ControllerBase
{
    private readonly RepairInfoService _repairInfoService;

    public RepairInfosController(RepairInfoService repairInfoService)
    {
        _repairInfoService = repairInfoService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<RepairInfo>> GetAll()
    {
        return Ok(_repairInfoService.GetAllRepairInfos());
    }

    [HttpGet("{id}")]
    public ActionResult<RepairInfo> GetById(int id)
    {
        var repairInfo = _repairInfoService.GetById(id);
        if (repairInfo == null)
        {
            return NotFound();
        }
        return Ok(repairInfo);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<RepairInfo>> Search([FromQuery] string query)
    {
        return Ok(_repairInfoService.SearchRepairInfos(query));
    }

    [HttpPost]
    public IActionResult Create([FromBody] RepairInfo repairInfo)
    {
        if (repairInfo == null)
        {
            return BadRequest();
        }
        _repairInfoService.AddRepairInfo(repairInfo);
        return CreatedAtAction(nameof(GetById), new { id = repairInfo.RepairId }, repairInfo);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] RepairInfo repairInfo)
    {
        if (id != repairInfo.RepairId)
        {
            return BadRequest();
        }
        _repairInfoService.UpdateRepairInfo(repairInfo);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repairInfoService.DeleteRepairInfo(id);
        return NoContent();
    }
}