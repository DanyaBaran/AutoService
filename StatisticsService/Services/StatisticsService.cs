using AutoService.Shared.Models;
using StatisticsService.Api.ApiClients;

namespace StatisticsService.Api.Services
{
    public class StatisticService
    {
        private readonly RepairApiClient _repairApiClient;
        private readonly GarageApiClient _garageApiClient;

        public StatisticService(RepairApiClient repairApiClient, GarageApiClient garageApiClient)
        {
            _repairApiClient = repairApiClient;
            _garageApiClient = garageApiClient;
        }

        public async Task<Dictionary<int, int>> GetRepairsPerMonthAsync()
        {
            var allRepairs = await _repairApiClient.GetAllAsync() ?? new List<Repair>();

            return allRepairs
                .GroupBy(r => r.DateBegin.Month)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<int, int>> GetRepairsPerYearAsync()
        {
            var allRepairs = await _repairApiClient.GetAllAsync() ?? new List<Repair>();

            return allRepairs
                .GroupBy(r => r.DateBegin.Year)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<string, int>> GetPopularCarMarksAsync()
        {
            var allRepairs = await _repairApiClient.GetAllAsync() ?? new List<Repair>();
            var allCars = await _garageApiClient.GetAllAsync() ?? new List<Car>();

            if (!allRepairs.Any() || !allCars.Any())
            {
                return new Dictionary<string, int>();
            }

            var carIdToMarkMap = allCars.ToDictionary(c => c.IdCar, c => c.NameMark);

            return allRepairs
                .GroupBy(r => carIdToMarkMap[r.CarId])
                .ToDictionary(g => g.Key, g => g.Count())
                .OrderByDescending(kvp => kvp.Value)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}
