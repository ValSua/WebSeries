using Infrastructure.Interface.Peliculas;
using Microsoft.EntityFrameworkCore;
using WebSeries.Data;
using WebSeries.Models;

namespace Infrastructure.Implements.Peliculas
{
    public class PeliculasRepository : IPeliculasRepository
    {
        private readonly ProjectDbContext _context;

        public PeliculasRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pelicula>> GetPeliculas()
        {
            return await _context.Peliculas
                        .Where(a => !a.IsDeleted)
                        .Include(a => a.Actors)
                        .Include(a => a.Directors)
                        .Include(a => a.Genero)
                        .Include(a => a.Pais)
                        .ToListAsync();
        }

        public async Task<Pelicula> GetPeliculaById(long id)
        {
            var pelicula = await _context.Peliculas
                              .Include(a => a.Actors)
                              .Include(a => a.Directors)
                              .Include(a => a.Genero)
                              .Include(a => a.Pais)
                              .FirstOrDefaultAsync(a => a.PeliculaId == id);

            if (pelicula == null)
                throw new KeyNotFoundException($"No se encontró una pelicula con ID {id}.");

            return pelicula;
        }
    }
}
