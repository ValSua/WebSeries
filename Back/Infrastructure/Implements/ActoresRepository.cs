using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using WebSeries.Data;
using WebSeries.Models;

namespace Infrastructure.Implements
{
    public class ActoresRepository : IActoresRepository
    {
        private readonly ProjectDbContext _context;

        public ActoresRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actore>> GetActores()
        {
            return await _context.Actores
                .Join(
                    _context.Paises,
                    actor => actor.PaisId,
                    pais => pais.PaisId,
                    (actor, pais) => new Actore
                    {
                        ActorId = actor.ActorId,
                        Nombre = actor.Nombre,
                        Apellido = actor.Apellido,
                        PaisId = actor.PaisId,
                        PaisNombre = actor.Pais.Nombre
                    })
                .ToListAsync();
        }

        public async Task<Actore> GetActorById(long id)
        {
            var actor = await _context.Actores
                      .Join(
                          _context.Paises,
                          actor => actor.PaisId,
                          pais => pais.PaisId,
                          (actor, pais) => new Actore
                          {
                              ActorId = actor.ActorId,
                              Nombre = actor.Nombre,
                              Apellido = actor.Apellido,
                              PaisId = actor.PaisId,
                              PaisNombre = pais.Nombre
                          })
                      .FirstOrDefaultAsync(a => a.ActorId == id);

            if (actor == null)
                throw new KeyNotFoundException($"No se encontró un actor con ID {id}.");

            return actor;
        }
    }
}
