using AutoService.Shared.Models;
using RepairService.Api.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService _employeeService;
    public EmployeesController(EmployeeService service) { _employeeService = service; }

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetAll() => Ok(_employeeService.GetAllEmployees());

    [HttpGet("{id}")]
    public ActionResult<Employee> GetById(int id)
    {
        var item = _employeeService.GetById(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<Employee>> Search([FromQuery] string query) => Ok(_employeeService.SearchEmployees(query));

    [HttpPost]
    public IActionResult Create([FromBody] Employee employee)
    {
        _employeeService.AddEmployee(employee);
        return CreatedAtAction(nameof(GetById), new { id = employee.IdEmployee }, employee);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Employee employee)
    {
        if (id != employee.IdEmployee) return BadRequest();
        _employeeService.UpdateEmployee(employee);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _employeeService.DeleteEmployee(id);
        return NoContent();
    }
}