using EmployeeWeb.Models;
using EmployeeWeb.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWeb.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = new List<EmployeeSalary>();
            try
            {
               employees = await _employeeService.GetEmployeesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = new Employee();
            try
            {
                employee = await _employeeService.GetEmployeeByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(employee);
        }

    }
}
