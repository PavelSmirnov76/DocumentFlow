using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DocumentFlow.Server.Data;
using DocumentFlow.Server.Models;

namespace DocumentFlow.Server.Controllers
{
    [Route("api/States")]
    [ApiController]
    public class StatesController : Controller
    {
        private readonly DocumentFlowServerContext _context;

        public StatesController(DocumentFlowServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            return await _context.States.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetState(long id)
        {
            var state = await _context.States.FirstOrDefaultAsync(m => m.Id == id);

            if (state == null)
            {
                return NotFound();
            }

            return state;
        }

        [HttpPost]
        public async Task<ActionResult<State>> PostState(State state)
        {
            await _context.States.AddAsync(state);

            await _context.SaveChangesAsync();

            return base.CreatedAtAction(nameof(GetState), new { id = state.Id }, state);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutState(long id, State state)
        {
            if (id != state.Id)
            {
                return BadRequest();
            }

            if (!StateExists(id))
            {
                return NotFound();
            }

            _context.Entry(state).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteState(long id)
        {
            var state = await _context.States.FindAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            _context.States.Remove(state);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StateExists(long id)
        {
            return (_context.States?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
