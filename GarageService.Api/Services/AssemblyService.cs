using GarageService.Api.Interfaces;
using AutoService.Shared.Models;

namespace GarageService.Api.Services
{
    public class AssemblyService
    {
        private readonly IAssemblyRepository _assemblyRepository;

        public AssemblyService(IAssemblyRepository assemblyRepository)
        {
            _assemblyRepository = assemblyRepository;
        }

        public IEnumerable<Assembly> GetAllAssemblys() => _assemblyRepository.GetAll();
        public Assembly GetById(int id) => _assemblyRepository.GetById(id);
        public void AddAssembly(Assembly assembly) => _assemblyRepository.Add(assembly);
        public void UpdateAssembly(Assembly assembly) => _assemblyRepository.Update(assembly);
        public void DeleteAssembly(int assemblyId) => _assemblyRepository.Delete(assemblyId);
        public IEnumerable<Assembly> SearchAssemblys(string searchQuery) => _assemblyRepository.SearchAssemblys(searchQuery);
    }
}
