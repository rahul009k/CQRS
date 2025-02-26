using CQRS.Data.Quries;
using CQRS.Models;
using CQRS.Services;
using MediatR;

namespace CQRS.Data.Handler
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private IEmployeeRepository _employee;

        public GetEmployeeByIdHandler(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
           if(request.Id<=0)
            {
                throw new Exception($"Employee with ID {request.Id} not found.");
                
            }
            var employee = await _employee.GetEmployeeById(request.Id);
            if(employee==null)
            {
                throw new Exception($"Employee with ID {request.Id} not found.");
            }
            return employee;
        }
    }
}
