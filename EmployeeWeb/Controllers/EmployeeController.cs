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
            try
            {
                var employees = await _employeeService.GetEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Please try again later.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(string id)
        {
            try
            {
                if (!int.TryParse(id, out int employeeId))
                {
                    return BadRequest("Invalid employee ID");
                }

                var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {employeeId} not found.");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Please try again later.");
            }
        }

    }
}
