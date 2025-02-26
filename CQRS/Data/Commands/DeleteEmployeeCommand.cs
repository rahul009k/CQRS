using CQRS.Models;
using MediatR;

namespace CQRS.Data.Commands
{
    public class DeleteEmployeeCommand:IRequest<int>
    {
        public int Id { get; set; }

        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }
    }
}
