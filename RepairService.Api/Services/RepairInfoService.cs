using RepairService.Api.Interfaces;
using AutoService.Shared.Models;

namespace RepairService.Api.Services
{
    public class RepairInfoService
    {
        private readonly IRepairInfoRepository _repairInfoRepository;

        public RepairInfoService(IRepairInfoRepository repairInfoRepository)
        {
            _repairInfoRepository = repairInfoRepository;
        }

        public IEnumerable<RepairInfo> GetAllRepairInfos() => _repairInfoRepository.GetAll();
        public RepairInfo GetById(int id) => _repairInfoRepository.GetById(id);
        public void AddRepairInfo(RepairInfo repairInfo) => _repairInfoRepository.Add(repairInfo);
        public void UpdateRepairInfo(RepairInfo repairInfo) => _repairInfoRepository.Update(repairInfo);
        public void DeleteRepairInfo(int repairInfoId) => _repairInfoRepository.Delete(repairInfoId);
        public IEnumerable<RepairInfo> SearchRepairInfos(string searchQuery) => _repairInfoRepository.SearchRepairInfos(searchQuery);
    }
}
