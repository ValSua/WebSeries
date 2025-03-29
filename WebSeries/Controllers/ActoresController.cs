using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSeries.Data;
using WebSeries.Models;

namespace WebSeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ProjectDbContext _context;

        public ActoresController(ProjectDbContext context)
        {
            _context = context;
        }

        // GET: api/Actores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actore>>> GetActores()
        {
            return await _context.Actores.ToListAsync();
        }

        // GET: api/Actores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actore>> GetActore(long id)
        {
            var actore = await _context.Actores.FindAsync(id);

            if (actore == null)
            {
                return NotFound();
            }

            return actore;
        }

        // PUT: api/Actores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActore(long id, Actore actore)
        {
            if (id != actore.ActorId)
            {
                return BadRequest();
            }

            _context.Entry(actore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Actores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Actore>> PostActore(Actore actore)
        {
            _context.Actores.Add(actore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActore", new { id = actore.ActorId }, actore);
        }

        // DELETE: api/Actores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActore(long id)
        {
            var actore = await _context.Actores.FindAsync(id);
            if (actore == null)
            {
                return NotFound();
            }

            _context.Actores.Remove(actore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActoreExists(long id)
        {
            return _context.Actores.Any(e => e.ActorId == id);
        }
    }
}
