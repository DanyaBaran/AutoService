using AutoService.Shared.Interfaces;
using AutoService.Shared.Models;

namespace GarageService.Api.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> SearchCars(string searchQuery);
    }
}
