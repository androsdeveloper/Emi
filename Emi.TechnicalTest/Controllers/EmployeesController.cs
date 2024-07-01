
namespace Emi.TechnicalTest.Controllers
{
    using Emi.TechnicalTest.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Emi.TechnicalTest.BusinessLogic.Dto;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var employeesResult = await _employeeService.GetAllEmployees();

            if (employeesResult == null)
            {
                return NotFound();
            }

            return Ok(employeesResult);
        }

        [HttpGet("calculatesyearlybonus")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult<Employee>> GetBonus()
        {
            var result = await _employeeService.GetBonus();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employeesResult = await _employeeService.GetEmployeeById(id);

            if (employeesResult == null)
            {
                return NotFound();
            }
            return Ok(employeesResult);

        }        

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> PostProduct(Employee employee)
        {
            int newEmployeeId = await _employeeService.AddEmployee(employee);
            employee.EmployeeId = newEmployeeId;
            return CreatedAtAction(nameof(GetEmployee), new { id = newEmployeeId }, employee);

        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> PutProduct(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            await _employeeService.UpdateEmployee(employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return NoContent();
        }

        [HttpGet("GetEmployeesByDepartment/")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees(int departmentId)
        {

            var employeesResult = await _employeeService.GetEmployeesByDepartmentAndProject(departmentId);

            if (employeesResult == null)
            {
                return NotFound();
            }

            return Ok(employeesResult);
        }
    }
}
