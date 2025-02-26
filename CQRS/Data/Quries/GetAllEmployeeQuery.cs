using CQRS.Models;
using MediatR;

namespace CQRS.Data.Quries
{
    public class GetAllEmployeeQuery:IRequest<List<Employee>>
    {
    }
}
