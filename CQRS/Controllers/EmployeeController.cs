using CQRS.Data.Commands;
using CQRS.Data.Quries;
using CQRS.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("GetEmployeeList")]
        public async Task<List<Employee>> GetEmployeeList()
        {
            var employeelist = await _mediator.Send(new GetAllEmployeeQuery());
            return employeelist;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        [Route("GetEmployeeById/{id}")]
        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
            return employee;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Route("AddNewEmployee")]
        public async Task<Employee> AddNewEmployee(Employee employee)
        {
            var emp = await _mediator.Send(new AddNewEmployeeCommand
            (employee.Name, employee.Email, employee.Phone));
            return emp;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        [Route("UpdateEmployee/{id}")]
        public async Task<int> UpdateEmployee(Employee employee)
        {
            var emp = await _mediator.Send(new UpdateEmployeeCommand
            (employee.id, employee.Name, employee.Email, employee.Phone));
            return emp;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        [Route("DeleteEmpolyee/{id}")]
        public async Task<int> DeleteEmpolyee(int id)
        {
            return await _mediator.Send(new DeleteEmployeeCommand(id));
             
        }
    }
}
