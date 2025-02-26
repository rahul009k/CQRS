using CQRS.Models;

namespace CQRS.Services
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployeeById(int Id);
        public Task<Employee> CreateEmployee(Employee employee);
        public Task<int> UpdateEmployee(Employee employee);
        public Task<int> DeleteEmployee(int id);
    }
}
