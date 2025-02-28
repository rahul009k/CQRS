

using CQRS.Controllers;
using CQRS.Data.Quries;
using CQRS.Models;
using MediatR;
using Moq;

namespace CQRS_TEST
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly EmployeeController _controller;

        public EmployeeControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new EmployeeController(_mockMediator.Object);
        }
        [Fact]
        public async Task GetEmployeeList_ReturnsCompleteEmployeeList_true()
        {
            var mockEmployees = new List<Employee>
            {
                new Employee { id = 1, Name = "John", Email = "john@example.com", Phone = "123456789" },
                new Employee { id = 2, Name = "Jane", Email = "jane@example.com", Phone = "987654321" }
            };

            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllEmployeeQuery>(), default))
                .ReturnsAsync(mockEmployees);

            // Act: Call the method
            var result = await _controller.GetEmployeeList();

            // Assert: Verify that the result is a list of employees
            var actionResult = Assert.IsType<List<Employee>>(result);
            Assert.Equal(2, actionResult.Count); // Verifying the count of employees

        }
        [Fact]
        public async Task GetEmployeeList_true()
        {
            var mockEmployees = new List<Employee>
            {
                new Employee { id = 1, Name = "John", Email = "john@example.com", Phone = "123456789" },
                new Employee { id = 2, Name = "Jane", Email = "jane@example.com", Phone = "987654321" }
            };
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllEmployeeQuery>(), default)).ReturnsAsync(mockEmployees);
            var result = await _controller.GetEmployeeList();
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task GetEmployeeList_IsEmpty()
        {
            var mockEmployees = new List<Employee>();
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllEmployeeQuery>(), default)).ReturnsAsync(mockEmployees);
            var result = await _controller.GetEmployeeList();
            Assert.Empty(result);
        }
    }
}
