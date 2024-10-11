using EmployeeWeb.ExternalServices.Contracts;
using EmployeeWeb.Models;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace EmployeeWeb.ExternalServices.Impl
{
    public class EmployeeExternalService : IEmployeeExternalService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _employeeListUrl;
        private readonly string _employeeByIdUrl;

        public EmployeeExternalService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _employeeListUrl = _configuration["ApiSettings:EmployeeApiBaseUrl"];
            _employeeByIdUrl = _configuration["ApiSettings:EmployeeByIdUrl"];
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee result = new Employee();
            try
            {
                string urlRequest = $"{_employeeByIdUrl}{id}";
                var response = await _httpClient.GetStringAsync(urlRequest);
                if (!string.IsNullOrEmpty(response))
                {
                    var employees = JsonSerializer.Deserialize<List<Employee>>(response);
                    result = employees.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> result = new List<Employee>();
            try
            {
                var response = await _httpClient.GetStringAsync(_employeeListUrl);
                if (!string.IsNullOrEmpty(response))
                {
                    result = JsonSerializer.Deserialize<List<Employee>>(response);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}