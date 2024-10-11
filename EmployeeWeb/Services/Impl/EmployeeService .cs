using EmployeeWeb.Enums;
using EmployeeWeb.ExternalServices.Contracts;
using EmployeeWeb.Models;
using EmployeeWeb.Services.Contracts;

namespace EmployeeWeb.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeExternalService _employeeExternalService;

        public EmployeeService(IEmployeeExternalService employeeExternalService) 
        {
            _employeeExternalService = employeeExternalService;
        }

        public async Task<EmployeeSalary> GetEmployeeByIdAsync(int id)
        {
            Employee employee = await _employeeExternalService.GetEmployeeById(id);
            EmployeeSalary result = GetEmployeeSalary(employee);
            return result;
        }

        public async Task<List<EmployeeSalary>> GetEmployeesAsync()
        {
            var result = new List<EmployeeSalary>();
            var employees = await _employeeExternalService.GetEmployeesAsync();
            foreach (var employee in employees)
            {
                result.Add(GetEmployeeSalary(employee));
            }
            return result;
        }

        private decimal GetAnnualSalary(decimal salary)
        {
            return salary * (Int32)TIME.MonthsPerYear;
        }

        private EmployeeSalary GetEmployeeSalary(Employee employee)
        {
            var result = new EmployeeSalary();
            result.Id = employee.Id;
            result.Address = employee.Address;
            result.Email = employee.Email;
            result.FirstName = employee.FirstName;
            result.LastName = employee.LastName;
            result.Age = employee.Age;
            result.ContactNumber = employee.ContactNumber;
            result.AnnualSalary = GetAnnualSalary(employee.Salary);
            result.ImageUrl = employee.ImageUrl;
            result.Dob = employee.Dob;
            result.Salary = employee.Salary;

            return result;
        }
    }
}
