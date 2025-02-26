using CQRS.Data.Quries;
using CQRS.Models;
using CQRS.Services;
using MediatR;

namespace CQRS.Data.Handler
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, List<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetAllEmployees();
        }
    }
}
