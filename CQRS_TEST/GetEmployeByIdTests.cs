using CQRS.Controllers;
using CQRS.Data.Quries;
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
    public class GetEmployeByIdTests
    {
        private readonly Mock<IMediator> _mockmeditor;
        private readonly EmployeeController _employeeController;
        public GetEmployeByIdTests()
        {
            _mockmeditor = new Mock<IMediator>();
            _employeeController = new EmployeeController(_mockmeditor.Object);
        }
        [Fact]
        public async Task GetEmployeByIdTests_ReturnsEmployee_true()
        {
            var _mockEmployee = new Employee()
            {
                id = 1,
                Name = "Rahul",
                Email = "",
                Phone = ""
            };
            _mockmeditor.Setup(m => m.Send(It.IsAny<GetEmployeeByIdQuery>(), default)).ReturnsAsync(_mockEmployee);
            var result = await _employeeController.GetEmployeeById(1);
           
            Assert.NotNull(result);
            Assert.Equal(1, result.id);

        }
        [Fact]
        public async Task GetEmployeeById_ReturnsNull_WhenIdIsInvalid()
        {
            var _mockEmployee = new Employee()
            {
                id = 1,
                Name = "Rahul",
                Email = "",
                Phone = ""
            };
            _mockmeditor.Setup(m => m.Send(It.Is<GetEmployeeByIdQuery>(q => q.Id == 1), It.IsAny<CancellationToken>())).ReturnsAsync(_mockEmployee);
            _mockmeditor.Setup(m => m.Send(It.Is<GetEmployeeByIdQuery>(q => q.Id == 2), It.IsAny<CancellationToken>())).ReturnsAsync((Employee?)null);

            var result = await _employeeController.GetEmployeeById(2);
            Assert.Null(result);
        }
        }
}

