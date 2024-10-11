using EmployeeWeb.ExternalServices.Contracts;
using EmployeeWeb.Models;
using EmployeeWeb.Services.Impl;
using Moq;

namespace EmployeeWebTest.Services
{
    [TestFixture]
    public class EmployeeServiceTest
    {
        private Mock<IEmployeeExternalService> _employeeExternalServiceMock;
        private EmployeeService _employeeService;

        [SetUp]
        public void Setup()
        {
            _employeeExternalServiceMock = new Mock<IEmployeeExternalService>();
            _employeeService = new EmployeeService(_employeeExternalServiceMock.Object);
        }

        [Test]
        public async Task GetEmployeeByIdAsync_ReturnsCorrectEmployeeSalary()
        {
            // Arrange
            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Andrea",
                LastName = "Pulido",
                Salary = 1000,
                Address = "123 calle falsa",
                Email = "puli1515@gmail.com",
                Age = 30,
                ContactNumber = "1234567890",
                ImageUrl = "http://example.com/image.png",
                Dob = "23/10/1993"
            };
            _employeeExternalServiceMock.Setup(service => service.GetEmployeeById(It.IsAny<int>())).ReturnsAsync(employee);

            // Act
            var result = await _employeeService.GetEmployeeByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employee.Id, result.Id);
            Assert.AreEqual(employee.FirstName, result.FirstName);
            Assert.AreEqual(employee.LastName, result.LastName);
            Assert.AreEqual(employee.Address, result.Address);
            Assert.AreEqual(employee.Email, result.Email);
            Assert.AreEqual(employee.Age, result.Age);
            Assert.AreEqual(employee.ContactNumber, result.ContactNumber);
            Assert.AreEqual(employee.Salary, result.Salary);
            Assert.AreEqual(employee.ImageUrl, result.ImageUrl);
            Assert.AreEqual(employee.Dob, result.Dob);
            Assert.AreEqual(12000, result.AnnualSalary); 
        }

        [Test]
        public void GetEmployeeByIdAsync_ThrowsException_WhenEmployeeIsNull()
        {
            // Arrange
            _employeeExternalServiceMock.Setup(service =>
                service.GetEmployeeById(It.IsAny<int>()))
                .ReturnsAsync((Employee)null);


            Assert.ThrowsAsync<NullReferenceException>(async () => await _employeeService.GetEmployeeByIdAsync(1));
        }

        [Test]
        public async Task GetEmployeesAsync_ReturnsListOfEmployeeSalaries()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Andrea", LastName = "Pulido", Salary = 1000 },
                new Employee { Id = 2, FirstName = "Yesica", LastName = "Escobar", Salary = 1500 }
            };
            _employeeExternalServiceMock.Setup(service => service.GetEmployeesAsync()).ReturnsAsync(employees);

            // Act
            var result = await _employeeService.GetEmployeesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(12000, result[0].AnnualSalary); 
            Assert.AreEqual(18000, result[1].AnnualSalary); 
        }
    }
}
