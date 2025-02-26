using CQRS.Data.Commands;
using CQRS.Models;
using CQRS.Services;
using MediatR;

namespace CQRS.Data.Handler
{
    public class AddNewEmployeeHandler : IRequestHandler<AddNewEmployeeCommand, Employee>
    {
        private IEmployeeRepository _employee;

        public AddNewEmployeeHandler(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        public async Task<Employee> Handle(AddNewEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = new Employee()
            {
                Name = request.Name,
                Email=request.Email,
                Phone=request.Phone
            };
            return await _employee.CreateEmployee(employee);

        }
    }
}
