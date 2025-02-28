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
    public class UpdateEmployeeTests
    {
        private readonly Mock<IMediator> _mockmeditor;
        private readonly EmployeeController _employeeController;
        public UpdateEmployeeTests()
        {
            _mockmeditor = new Mock<IMediator>();
            _employeeController=new EmployeeController(_mockmeditor.Object);
        }
        [Fact]
        public async Task UpdateEmployeeTest_ReturnsEmployee_true()
        {
            var _mockEmployee = new Employee()
            {
                id = 1,
                Name = "Rahul",
                Email = "",
                Phone = ""
            };
            _mockmeditor.Setup(m => m.Send(It.IsAny<UpdateEmployeeCommand>(), default)).ReturnsAsync(_mockEmployee);
            var result = await _employeeController.UpdateEmployee(_mockEmployee);
          Assert.NotNull(result);
            Assert.Equal(1, result.id);
            Assert.Equal("Rahul", result.Name);
        }
        [Fact]
        public async Task UpdateEmployeeTest_ReturnsEmployee_false()
        {
            var _mockEmployee = new Employee()
            {
                id = 1,
                Name = "Rahul",
                Email = "",
                Phone = ""
            };
            _mockmeditor.Setup(m => m.Send(It.IsAny<UpdateEmployeeCommand>(), default)).ReturnsAsync((Employee)null);
            var result = await _employeeController.UpdateEmployee(_mockEmployee);
            Assert.Null(result);
        }
    }
}
