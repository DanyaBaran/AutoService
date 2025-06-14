using AutoService.Shared.Interfaces;
using AutoService.Shared.Models;

namespace GarageService.Api.Interfaces
{
    public interface IAssemblyRepository : IRepository<Assembly>
    {
        IEnumerable<Assembly> SearchAssemblys(string searchQuery);
    }
}
