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
    public class DeleteTestEmployee
    {
        private readonly Mock<IMediator> _mockmeditor;
        private readonly EmployeeController employeeController;
        public DeleteTestEmployee()
        {
            _mockmeditor = new Mock<IMediator>();
            employeeController = new EmployeeController(_mockmeditor.Object);
        }
        [Fact]
        public async Task DeleteEmployeeTest_ReturnsEmployee_true()
        {
            _mockmeditor.Setup(m => m.Send(It.IsAny<DeleteEmployeeCommand>(), default)).ReturnsAsync(1);

            var result = await employeeController.DeleteEmpolyee(1);

            Assert.Equal(1, result);
        }
        [Fact]
        public async Task DeleteEmployeeTest_InvalidId_returns_false()
        {
           
            _mockmeditor.Setup(m => m.Send(It.IsAny<DeleteEmployeeCommand>(), default)).ReturnsAsync(1);
            _mockmeditor.Setup(m => m.Send(It.IsAny<DeleteEmployeeCommand>(), default)).ReturnsAsync(0);

            var result = await employeeController.DeleteEmpolyee(2);

            Assert.Equal(0, result);
        }
    }
}
