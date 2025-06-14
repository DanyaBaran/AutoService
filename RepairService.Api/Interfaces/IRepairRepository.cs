using AutoService.Shared.Models;
using AutoService.Shared.Interfaces;

namespace RepairService.Api.Interfaces
{
    public interface IRepairRepository : IRepository<Repair>
    {
        IEnumerable<Repair> SearchRepairs(string searchQuery);
    }
}
