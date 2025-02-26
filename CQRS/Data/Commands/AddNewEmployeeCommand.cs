using CQRS.Models;
using MediatR;

namespace CQRS.Data.Commands
{
    public class AddNewEmployeeCommand:IRequest<Employee>
    {
        public AddNewEmployeeCommand( string name, string email, string phone)
        {
            
            Name = name;
            Email = email;
            Phone = phone;
        }

       
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
    }
}
