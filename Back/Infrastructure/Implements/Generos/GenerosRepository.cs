using Infrastructure.Interface.Generos;
using Microsoft.EntityFrameworkCore;
using Transversal.Dto.Generos;
using WebSeries.Data;
using WebSeries.Models;

namespace Infrastructure.Implements.Generos
{
    public class GenerosRepository : IGenerosRepository
    {
        private readonly ProjectDbContext _context;

        public GenerosRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genero>> GetGeneros()
        {
            return await _context.Generos
                        .Where(a => !a.IsDeleted)
                        .ToListAsync();
        }

        public async Task<Genero> GetGeneroById(long id)
        {
            var genero = await _context.Generos
                              .FirstOrDefaultAsync(a => a.GeneroId == id);

            if (genero == null)
                throw new KeyNotFoundException($"No se encontró un genero con ID {id}.");

            return genero;
        }

        public async Task<bool> UpdateGenero(long id, Genero genero)
        {
            if (id != genero.GeneroId)
            {
                return false;
            }

            _context.Entry(genero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneroExists(id))
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

        private bool GeneroExists(long id)
        {
            return _context.Generos.Any(e => e.GeneroId == id);
        }

        public async Task<CreateGeneroDto> CreateGenero(Genero genero)
        {
            _context.Generos.Add(genero);
            await _context.SaveChangesAsync();

            return new CreateGeneroDto
            {
                GeneroId = genero.GeneroId,
                Nombre = genero.Nombre
            };
        }

        public async Task<bool> DeleteGenero(long id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero == null)
            {
                return false;
            }

            genero.IsDeleted = true;

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
