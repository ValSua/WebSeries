using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSeries.Data;
using WebSeries.Models;

namespace WebSeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoresController : ControllerBase
    {
        private readonly ProjectDbContext _context;

        public DirectoresController(ProjectDbContext context)
        {
            _context = context;
        }

        // GET: api/Directores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Directore>>> GetDirectores()
        {
            return await _context.Directores.ToListAsync();
        }

        // GET: api/Directores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Directore>> GetDirectore(long id)
        {
            var directore = await _context.Directores.FindAsync(id);

            if (directore == null)
            {
                return NotFound();
            }

            return directore;
        }

        // PUT: api/Directores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectore(long id, Directore directore)
        {
            if (id != directore.DirectorId)
            {
                return BadRequest();
            }

            _context.Entry(directore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectoreExists(id))
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

        // POST: api/Directores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Directore>> PostDirectore(Directore directore)
        {
            _context.Directores.Add(directore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirectore", new { id = directore.DirectorId }, directore);
        }

        // DELETE: api/Directores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirectore(long id)
        {
            var directore = await _context.Directores.FindAsync(id);
            if (directore == null)
            {
                return NotFound();
            }

            _context.Directores.Remove(directore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirectoreExists(long id)
        {
            return _context.Directores.Any(e => e.DirectorId == id);
        }
    }
}
