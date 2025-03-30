using Aplication.Interface;
using Microsoft.AspNetCore.Mvc;
using Transversal.Helpers;
using WebSeries.Models;

namespace WebSeries.Controllers
{
    [ApiController]
    public class ActoresController : ControllerBase
    {
        /// <summary>
        /// The actores service
        /// </summary>
        private readonly IActoresService _actoresService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActoresController"/> class.
        /// </summary>
        /// <param name="actoresService">The actores service.</param>
        public ActoresController(IActoresService actoresService)
        {
            _actoresService = actoresService;
        }

        /// <summary>
        /// Gets the actores.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPath.Actores.GetActores)]
        public async Task<IEnumerable<Actore>> GetActores() => await _actoresService.GetActores();

        [HttpGet(RoutesPath.Actores.GetActorById)]
        public async Task<Actore> GetActorById(long id) => await _actoresService.GetActorById(id);

        //// PUT: api/Actores/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutActore(long id, Actore actore)
        //{
        //    if (id != actore.ActorId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(actore).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ActoreExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Actores
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Actore>> PostActore(Actore actore)
        //{
        //    _context.Actores.Add(actore);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetActore", new { id = actore.ActorId }, actore);
        //}

        //// DELETE: api/Actores/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteActore(long id)
        //{
        //    var actore = await _context.Actores.FindAsync(id);
        //    if (actore == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Actores.Remove(actore);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ActoreExists(long id)
        //{
        //    return _context.Actores.Any(e => e.ActorId == id);
        //}
    }
}
