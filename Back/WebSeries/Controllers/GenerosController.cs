//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebSeries.Data;
//using WebSeries.Models;

//namespace WebSeries.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GenerosController : ControllerBase
//    {
//        private readonly ProjectDbContext _context;

//        public GenerosController(ProjectDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Generos
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Genero>>> GetGeneros()
//        {
//            return await _context.Generos.ToListAsync();
//        }

//        // GET: api/Generos/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Genero>> GetGenero(long id)
//        {
//            var genero = await _context.Generos.FindAsync(id);

//            if (genero == null)
//            {
//                return NotFound();
//            }

//            return genero;
//        }

//        // PUT: api/Generos/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutGenero(long id, Genero genero)
//        {
//            if (id != genero.GeneroId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(genero).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!GeneroExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Generos
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Genero>> PostGenero(Genero genero)
//        {
//            _context.Generos.Add(genero);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetGenero", new { id = genero.GeneroId }, genero);
//        }

//        // DELETE: api/Generos/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteGenero(long id)
//        {
//            var genero = await _context.Generos.FindAsync(id);
//            if (genero == null)
//            {
//                return NotFound();
//            }

//            _context.Generos.Remove(genero);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool GeneroExists(long id)
//        {
//            return _context.Generos.Any(e => e.GeneroId == id);
//        }
//    }
//}
