using CQRS.Data.Commands;
using CQRS.Services;
using MediatR;

namespace CQRS.Data.Handler
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private IEmployeeRepository _employee;

        public DeleteEmployeeHandler(IEmployeeRepository employee)
        {
            _employee = employee;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employee.GetEmployeeById(request.Id);
            if(employee!=null)
            return await _employee.DeleteEmployee(request.Id);
            else
                throw new Exception($"Employee with ID {request.Id} not found.");

        }
    }
}
