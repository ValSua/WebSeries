//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebSeries.Data;
//using WebSeries.Models;

//namespace WebSeries.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PaisesController : ControllerBase
//    {
//        private readonly ProjectDbContext _context;

//        public PaisesController(ProjectDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Paises
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Paise>>> GetPaises()
//        {
//            return await _context.Paises.ToListAsync();
//        }

//        // GET: api/Paises/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Paise>> GetPaise(long id)
//        {
//            var paise = await _context.Paises.FindAsync(id);

//            if (paise == null)
//            {
//                return NotFound();
//            }

//            return paise;
//        }

//        // PUT: api/Paises/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutPaise(long id, Paise paise)
//        {
//            if (id != paise.PaisId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(paise).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!PaiseExists(id))
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

//        // POST: api/Paises
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Paise>> PostPaise(Paise paise)
//        {
//            _context.Paises.Add(paise);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetPaise", new { id = paise.PaisId }, paise);
//        }

//        // DELETE: api/Paises/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeletePaise(long id)
//        {
//            var paise = await _context.Paises.FindAsync(id);
//            if (paise == null)
//            {
//                return NotFound();
//            }

//            _context.Paises.Remove(paise);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool PaiseExists(long id)
//        {
//            return _context.Paises.Any(e => e.PaisId == id);
//        }
//    }
//}
