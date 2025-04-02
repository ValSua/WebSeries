using Infrastructure.Interface.Directores;
using Microsoft.EntityFrameworkCore;
using Transversal.Dto.Actores;
using Transversal.Dto.Directores;
using WebSeries.Data;
using WebSeries.Models;

namespace Infrastructure.Implements.Directores
{
    public class DirectoresRepository : IDirectoresRepository
    {
        private readonly ProjectDbContext _context;

        public DirectoresRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Directore>> GetDirectores()
        {
            return await _context.Directores
                        .Where(a => !a.IsDeleted)
                        .Include(a => a.Pais)
                        .Include(a => a.PeliculasDirectores)
                            .ThenInclude(pa => pa.Pelicula)
                        .ToListAsync();
        }

        public async Task<Directore> GetDirectorById(long id)
        {
            var director = await _context.Directores
                              .Include(a => a.Pais)
                              .Include(a => a.PeliculasDirectores)
                                 .ThenInclude(pa => pa.Pelicula)
                              .FirstOrDefaultAsync(a => a.DirectorId == id);

            if (director == null)
                throw new KeyNotFoundException($"No se encontró un director con ID {id}.");

            return director;
        }

        public async Task<bool> UpdateDirector(long id, Directore directore)
        {
            if (id != directore.DirectorId)
            {
                return false;
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
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }
        private bool DirectoreExists(long id)
        {
            return _context.Directores.Any(e => e.DirectorId == id);
        }

        public async Task<CreateDirectorDto> CreateDirector(Directore directore)
        {
            _context.Directores.Add(directore);
            await _context.SaveChangesAsync();

            return new CreateDirectorDto
            {
                DirectorId = directore.DirectorId,
                Nombre = directore.Nombre,
                Apellido = directore.Apellido,
                PaisId = directore.PaisId
            };
        }

        public async Task<bool> DeleteDirector(long id)
        {
            var director = await _context.Directores
                .FirstOrDefaultAsync(p => p.DirectorId == id);

            if (director == null)
            {
                return false;
            }

            director.IsDeleted = true;

            var relacionesDirectores = _context.PeliculasDirectores
                .Where(pa => pa.DirectorId == id)
                .ToList();

            foreach (var relacion in relacionesDirectores)
            {
                relacion.IsDeleted = true;
            }

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
