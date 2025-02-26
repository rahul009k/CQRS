using CQRS.Models;
using MediatR;

namespace CQRS.Data.Quries
{
    public class GetEmployeeByIdQuery:IRequest<Employee>
    {

       public int Id { get; set; }

        public GetEmployeeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
