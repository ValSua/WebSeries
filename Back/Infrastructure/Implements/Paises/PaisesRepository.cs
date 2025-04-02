using Infrastructure.Interface.Paises;
using Microsoft.EntityFrameworkCore;
using Transversal.Dto.Paises;
using WebSeries.Data;
using WebSeries.Models;

namespace Infrastructure.Implements.Paises
{
    public class PaisesRepository : IPaisesRepository
    {
        private readonly ProjectDbContext _context;

        public PaisesRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paise>> GetPaises()
        {
            return await _context.Paises
                        .Where(a => !a.IsDeleted)
                        .ToListAsync();
        }

        public async Task<Paise> GetPaisById(long id)
        {
            var genero = await _context.Paises
                              .FirstOrDefaultAsync(a => a.PaisId == id);

            if (genero == null)
                throw new KeyNotFoundException($"No se encontró un genero con ID {id}.");

            return genero;
        }

        public async Task<bool> UpdatePais(long id, Paise genero)
        {
            if (id != genero.PaisId)
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
                if (!PaisExists(id))
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

        private bool PaisExists(long id)
        {
            return _context.Paises.Any(e => e.PaisId == id);
        }

        public async Task<CreatePaisDto> CreatePais(Paise pais)
        {
            _context.Paises.Add(pais);
            await _context.SaveChangesAsync();

            return new CreatePaisDto
            {
                PaisId = pais.PaisId,
                Nombre = pais.Nombre
            };
        }

        public async Task<bool> DeletePais(long id)
        {
            var pais = await _context.Paises.FindAsync(id);
            if (pais == null)
            {
                return false;
            }

            pais.IsDeleted = true;

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
