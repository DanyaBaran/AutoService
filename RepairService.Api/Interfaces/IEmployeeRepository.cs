using AutoService.Shared.Models;
using AutoService.Shared.Interfaces;

namespace RepairService.Api.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> SearchEmployees(string searchQuery);
    }
}
