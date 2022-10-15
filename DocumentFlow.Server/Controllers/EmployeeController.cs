using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DocumentFlow.Model;
using DocumentFlow.Server.Data;
using DocumentFlow.Server.Models.Patch;

namespace DocumentFlow.Server.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly DocumentFlowServerContext _context;

        public EmployeesController(DocumentFlowServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.Include(e => e.Person).Include(e => e.Position).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            var employee = await _context.Employees.Include(e => e.Person).Include(e => e.Position)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);

            await _context.SaveChangesAsync();

            return await GetEmployee(employee.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutEmployee(long id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            if (!EmployeeExists(id))
            {
                return NotFound();
            }

            _context.Entry(employee).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Employee>> PatchEmployee(long id, PatchEmployeeDto employeeDto)
        {
            var oldEmployee = await _context.Employees.FindAsync(id);

            if (oldEmployee == null)
            {
                return NotFound();
            }

            if (employeeDto.IsFieldPresent(nameof(employeeDto.Person)))
                oldEmployee.Person = employeeDto.Person;
            if (employeeDto.IsFieldPresent(nameof(employeeDto.Position)))
                oldEmployee.Position = employeeDto.Position;
            if (employeeDto.IsFieldPresent(nameof(employeeDto.IsSignatory)))
                oldEmployee.IsSignatory = employeeDto.IsSignatory;
            if (employeeDto.IsFieldPresent(nameof(employeeDto.IsСoordinating)))
                oldEmployee.IsСoordinating = employeeDto.IsСoordinating;
            if (employeeDto.IsFieldPresent(nameof(employeeDto.IsAddressee)))
                oldEmployee.IsAddressee = employeeDto.IsAddressee;

            await _context.SaveChangesAsync();

            return Ok(oldEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(long id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool EmployeeExists(long id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
