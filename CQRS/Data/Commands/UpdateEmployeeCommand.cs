using CQRS.Models;
using MediatR;

namespace CQRS.Data.Commands
{
    public class UpdateEmployeeCommand:IRequest<int>
    {
        public UpdateEmployeeCommand(int id, string name, string email, string phone)
        {
            this.id = id;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public int id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
    }
}
