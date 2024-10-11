using EmployeeWeb.Models;

namespace EmployeeWeb.ExternalServices.Contracts
{
    public interface IEmployeeExternalService
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeById(int id);
    }
}
