using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DocumentFlow.Model;
using DocumentFlow.Server.Data;
using DocumentFlow.Server.Models;

namespace DocumentFlow.Server.Controllers
{
    [Route("api/Positions")]
    [ApiController]
    public class PositionsContriller : Controller
    {
        private readonly DocumentFlowServerContext _context;

        public PositionsContriller(DocumentFlowServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetPositions()
        {
            return await _context.Positions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetState(long id)
        {
            var position = await _context.Positions.FirstOrDefaultAsync(m => m.Id == id);

            if (position == null)
            {
                return NotFound();
            }

            return position;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPosition(Position position)
        {
            await _context.Positions.AddAsync(position);

            await _context.SaveChangesAsync();

            return base.CreatedAtAction(nameof(GetState), new { id = position.Id }, position);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutState(long id, Position position)
        {
            if (id != position.Id)
            {
                return BadRequest();
            }

            if (!PositionExists(id))
            {
                return NotFound();
            }

            _context.Entry(position).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePosition(long id)
        {
            var positions = await _context.Positions.FindAsync(id);

            if (positions == null)
            {
                return NotFound();
            }

            _context.Positions.Remove(positions);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PositionExists(long id)
        {
            return (_context.Positions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
