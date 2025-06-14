using AutoService.Shared.Models;
using GarageService.Api.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/cars")]
public class CarsController : ControllerBase
{
    private readonly CarService _carService;
    public CarsController(CarService carService) { _carService = carService; }

    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAll() => Ok(_carService.GetAllCars());

    [HttpGet("{id}")]
    public ActionResult<Car> GetById(int id)
    {
        var car = _carService.GetById(id);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<Car>> Search([FromQuery] string query) => Ok(_carService.SearchCars(query));

    [HttpPost]
    public IActionResult Create([FromBody] Car car)
    {
        if (car == null) return BadRequest();
        _carService.AddCar(car);
        return CreatedAtAction(nameof(GetById), new { id = car.IdCar }, car);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Car car)
    {
        if (id != car.IdCar) return BadRequest();
        _carService.UpdateCar(car);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _carService.DeleteCar(id);
        return NoContent();
    }
}