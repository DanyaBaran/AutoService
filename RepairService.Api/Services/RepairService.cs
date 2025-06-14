using RepairService.Api.Interfaces;
using AutoService.Shared.Models;

namespace RepairService.Api.Services
{
    public class RepairsService
    {
        private readonly IRepairRepository _repairRepository;

        public RepairsService(IRepairRepository repairRepository)
        {
            _repairRepository = repairRepository;
        }

        public IEnumerable<Repair> GetAllRepairs() => _repairRepository.GetAll();
        public Repair GetById(int id) => _repairRepository.GetById(id);
        public void AddRepair(Repair repair) => _repairRepository.Add(repair);
        public void UpdateRepair(Repair repair) => _repairRepository.Update(repair);
        public void DeleteRepair(int repairId) => _repairRepository.Delete(repairId);
        public IEnumerable<Repair> SearchRepairs(string searchQuery) => _repairRepository.SearchRepairs(searchQuery);
    }
}
