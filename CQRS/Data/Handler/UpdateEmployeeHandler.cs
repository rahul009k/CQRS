using CQRS.Data.Commands;
using CQRS.Models;
using CQRS.Services;
using MediatR;

namespace CQRS.Data.Handler
{
    public class UpdateEmployeeHandler:IRequestHandler<UpdateEmployeeCommand, Employee?>
    {
        private IEmployeeRepository _employee;

        public UpdateEmployeeHandler(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        public async Task<Employee?> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employee.GetEmployeeById(request.id);
            if(employee!=null)
            {
                employee.Name = request.Name;
                employee.Email = request.Email;
                employee.Phone = request.Phone;
                return await _employee.UpdateEmployee(employee);
            }
            else
                throw new Exception($"Employee with ID {request.id} not found.");

        }
    }
}
