using EmployeeWeb.Models;

namespace EmployeeWeb.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<List<EmployeeSalary>> GetEmployeesAsync();
        Task<EmployeeSalary> GetEmployeeByIdAsync(int id);
    }
}
