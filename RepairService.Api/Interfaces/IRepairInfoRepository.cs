using AutoService.Shared.Models;
using AutoService.Shared.Interfaces;

namespace RepairService.Api.Interfaces
{
    public interface IRepairInfoRepository : IRepository<RepairInfo>
    {
        IEnumerable<RepairInfo> SearchRepairInfos(string searchQuery);
    }
}
