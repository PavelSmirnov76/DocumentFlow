using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DocumentFlow.Model;
using DocumentFlow.Server.Data;
using DocumentFlow.Server.Models.Patch;

namespace DocumentFlow.Server.Controllers
{
    [Route("api/InternalDocuments")]
    [ApiController]
    public class InternalDocumentsController : ControllerBase
    {
        private readonly DocumentFlowServerContext _context;

        public InternalDocumentsController(DocumentFlowServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InternalDocument>>> GetDocuments()
        {
            return await _context.InternalDocuments.Include(e => e.Author).Include(e => e.State).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InternalDocument>> GetDocument(long id)
        {
            var document = await _context.InternalDocuments.Include(e => e.Author).Include((e) => e.Author!=null? e.Author.Person : null)
                .Include((e) => e.Author != null ? e.Author.Position : null).Include((e) => e.File).Include(e => e.State)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        [HttpPost]
        public async Task<ActionResult<InternalDocument>> PostDocument(InternalDocument document)
        {

            await _context.InternalDocuments.AddAsync(document);

            await _context.SaveChangesAsync();

            return await GetDocument(document.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutDocument(long id, InternalDocument document)
        {
            if (id != document.Id)
            {
                return BadRequest();
            }

            if (!DocumentExists(id))
            {
                return NotFound();
            }

            _context.Entry(document).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<InternalDocument>> PatchDocument(long id, PatchDocumentDto documentDto)
        {
            var oldDocument = await _context.InternalDocuments.FindAsync(id);

            if (oldDocument == null)
            {
                return NotFound();
            }

            if (documentDto.IsFieldPresent(nameof(documentDto.Hedder)))
                oldDocument.Header = documentDto.Hedder;
            if (documentDto.IsFieldPresent(nameof(documentDto.Author)))
                oldDocument.Author = documentDto.Author;
            if (documentDto.IsFieldPresent(nameof(documentDto.State)))
                oldDocument.State = documentDto.State;

            await _context.SaveChangesAsync();

            return Ok(oldDocument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDocument(long id)
        {
            var document = await _context.InternalDocuments.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            _context.InternalDocuments.Remove(document);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool DocumentExists(long id)
        {
            return (_context.InternalDocuments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
