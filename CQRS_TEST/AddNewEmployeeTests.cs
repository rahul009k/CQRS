using CQRS.Controllers;
using CQRS.Data.Commands;
using CQRS.Models;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_TEST
{
   public class AddNewEmployeeTests
    {
        private readonly Mock<IMediator> _mockmeditor;
        private readonly EmployeeController _employeeController;
        public AddNewEmployeeTests()
        {
            _mockmeditor = new Mock<IMediator>();
            _employeeController = new EmployeeController(_mockmeditor.Object);
        }
        [Fact]
        public async Task AddNewEmployeeTests_ReturnsEmployee_true()
        {
            var _mockEmployee = new Employee()
            {
                id = 1,
                Name = "Rahul",
                Email = "",
                Phone = ""
            };
            _mockmeditor.Setup(m => m.Send(It.IsAny<AddNewEmployeeCommand>(), default)).ReturnsAsync(_mockEmployee);
            var result = await _employeeController.AddNewEmployee(_mockEmployee);

            Assert.NotNull(result);
            Assert.Equal(1, result.id);
            Assert.Equal("Rahul", result.Name); 
        }
    }
}
