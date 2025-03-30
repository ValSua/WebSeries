//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebSeries.Data;
//using WebSeries.Models;

//namespace WebSeries.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PeliculasController : ControllerBase
//    {
//        private readonly ProjectDbContext _context;

//        public PeliculasController(ProjectDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Peliculas
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas()
//        {
//            return await _context.Peliculas.ToListAsync();
//        }

//        // GET: api/Peliculas/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Pelicula>> GetPelicula(long id)
//        {
//            var pelicula = await _context.Peliculas.FindAsync(id);

//            if (pelicula == null)
//            {
//                return NotFound();
//            }

//            return pelicula;
//        }

//        // PUT: api/Peliculas/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutPelicula(long id, Pelicula pelicula)
//        {
//            if (id != pelicula.PeliculaId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(pelicula).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!PeliculaExists(id))
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

//        // POST: api/Peliculas
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Pelicula>> PostPelicula(Pelicula pelicula)
//        {
//            _context.Peliculas.Add(pelicula);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetPelicula", new { id = pelicula.PeliculaId }, pelicula);
//        }

//        // DELETE: api/Peliculas/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeletePelicula(long id)
//        {
//            var pelicula = await _context.Peliculas.FindAsync(id);
//            if (pelicula == null)
//            {
//                return NotFound();
//            }

//            _context.Peliculas.Remove(pelicula);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool PeliculaExists(long id)
//        {
//            return _context.Peliculas.Any(e => e.PeliculaId == id);
//        }
//    }
//}
