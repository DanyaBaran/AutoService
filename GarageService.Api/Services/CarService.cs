using GarageService.Api.Interfaces;
using AutoService.Shared.Models;

namespace GarageService.Api.Services
{
    public class CarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IEnumerable<Car> GetAllCars() => _carRepository.GetAll();
        public Car GetById(int id) => _carRepository.GetById(id);
        public void AddCar(Car car) => _carRepository.Add(car);
        public void UpdateCar(Car car) => _carRepository.Update(car);
        public void DeleteCar(int carId) => _carRepository.Delete(carId);
        public IEnumerable<Car> SearchCars(string searchQuery) => _carRepository.SearchCars(searchQuery);
    }
}
