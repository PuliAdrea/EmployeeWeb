using EmployeeWeb.ExternalServices.Contracts;
using EmployeeWeb.Models;
using System.Text.Json;

namespace EmployeeWeb.ExternalServices.Impl
{
    public class EmployeeExternalService : IEmployeeExternalService
    {
        private readonly HttpClient _httpClient;

        public EmployeeExternalService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee result = new Employee();
            try
            {
                string urlRequest = $"http://hub.dummyapis.com/employee?noofRecords=1&idStarts={id}";
                var response = await _httpClient.GetStringAsync(urlRequest);
                if (!string.IsNullOrEmpty(response))
                {
                    var employees = JsonSerializer.Deserialize<List<Employee>>(response);
                    result = employees.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;   
                throw;
            }

                      
            return result;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> result = new List<Employee>();
            try
            {
                var response = await _httpClient.GetStringAsync("http://hub.dummyapis.com/employee");
                if (!string.IsNullOrEmpty(response))
                {
                    result = JsonSerializer.Deserialize<List<Employee>>(response);
                }
            }
            catch (Exception ex )
            {
                var err = ex.Message;
                throw;
            }
           
            return result;
        }
    }
}
