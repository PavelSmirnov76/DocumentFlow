using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DocumentFlow.Model;
using DocumentFlow.Server.Data;
using DocumentFlow.Server.Models.Patch;

namespace DocumentFlow.Server.Controllers
{
    [Route("api/Persons")]
    [ApiController]
    public class PersonsController : Controller
    {
        private readonly DocumentFlowServerContext _context;

        public PersonsController(DocumentFlowServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(long id)
        {
            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            await _context.Persons.AddAsync(person);

            await _context.SaveChangesAsync();

            return base.CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutPerson(long id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            if (!PersonExists(id))
            {
                return NotFound();
            }

            _context.Entry(person).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Person>> PatchPerson(long id, PatchPersonDto personDto)
        {
            var oldPerson = await _context.Persons.FindAsync(id);

            if (oldPerson == null)
            {
                return NotFound();
            }

            if (personDto.IsFieldPresent(nameof(personDto.FullName)))
                oldPerson.FullName = personDto.FullName;
            if (personDto.IsFieldPresent(nameof(personDto.Sex)))
                oldPerson.Sex = personDto.Sex;
            if (personDto.IsFieldPresent(nameof(personDto.DateBirth)))
                oldPerson.DateBirth = personDto.DateBirth;
            if (personDto.IsFieldPresent(nameof(personDto.PhoneNumber)))
                oldPerson.PhoneNumber = personDto.PhoneNumber;

            await _context.SaveChangesAsync();

            return Ok(oldPerson);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(long id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool PersonExists(long id)
        {
            return (_context.Persons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
