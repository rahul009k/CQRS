using CQRS.Data;
using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _dbContext;
        public EmployeeRepository(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var result = _dbContext.Add(employee);
            await _dbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<int> DeleteEmployee(int id)
        {
            var employee = await _dbContext.employees.FindAsync(id);
            if (employee != null)
            {
                _dbContext.employees.Remove(employee);
               await _dbContext.SaveChangesAsync();
                return 1;
            }
            else
                return 0;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _dbContext.employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int Id)
        {
            var employee = await _dbContext.employees.FindAsync(Id);
            if (employee != null)
            {
                return employee;
            }
            else throw new Exception($"Employee with ID {Id} not found.");
        }

        public async Task<Employee?> UpdateEmployee(Employee employee)
        {
            var record = await _dbContext.employees.FindAsync(employee.id);
            if (record != null)
            {
                record.Name = employee.Name;
                record.Email = employee.Email;
                record.Phone = employee.Phone;
                 await _dbContext.SaveChangesAsync();
                return record;
            }
            else return null;
        }
    }
}
