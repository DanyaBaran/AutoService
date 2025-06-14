using RepairService.Api.Interfaces;
using AutoService.Shared.Models;

namespace RepairService.Api.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAllEmployees() => _employeeRepository.GetAll();
        public Employee GetById(int id) => _employeeRepository.GetById(id);
        public void AddEmployee(Employee employee) => _employeeRepository.Add(employee);
        public void UpdateEmployee(Employee employee) => _employeeRepository.Update(employee);
        public void DeleteEmployee(int employeeId) => _employeeRepository.Delete(employeeId);
        public IEnumerable<Employee> SearchEmployees(string searchQuery) => _employeeRepository.SearchEmployees(searchQuery);
    }
}
