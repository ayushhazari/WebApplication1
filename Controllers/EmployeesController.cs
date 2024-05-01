
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        private readonly InfoContext _infoContext;

        public EmployeesController(InfoContext infoContext)
        {
            _infoContext = infoContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _infoContext.Employees.ToListAsync();
        }

       [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
          if (id < 1)
            return BadRequest();
            var emp = await _infoContext.Employees.FirstOrDefaultAsync(m => m.EmpId == id);
            if (emp == null)
                return NotFound();
            return Ok(emp);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee employee)
        {
            _infoContext.Add(employee);
            await _infoContext.SaveChangesAsync();
            return Ok();
        }
        

        [HttpPut]
        public async Task<IActionResult> Put(Employee employeeData)
        {
            if (employeeData == null || employeeData.EmpId == 0)
                return BadRequest();

            var employee = await _infoContext.Employees.FindAsync(employeeData.EmpId);
            if (employee == null)
                return NotFound();
            employee.Name = employeeData.Name;
            employee.Email = employeeData.Email;
            employee.CompanyName = employeeData.CompanyName;
            employee.Contact = employeeData.Contact;
            await _infoContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var employee = await _infoContext.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();
            _infoContext.Employees.Remove(employee);
            await _infoContext.SaveChangesAsync();
            return Ok();

        }

         [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]Login loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
                return BadRequest("Email and password are required.");

            var employee = await _infoContext.Employees.FirstOrDefaultAsync(e => e.Email == loginRequest.Email);

            if (employee == null || employee.Password != loginRequest.Password)
                return Unauthorized("Invalid email or password.");

            return Ok(new { Message = "Login successful!", EmployeeId = employee.EmpId });
        }



        

    }

    
}
