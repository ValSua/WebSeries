using Infrastructure.Interface.Peliculas;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Transversal.Dto.Peliculas;
using WebSeries.Data;
using WebSeries.Models;
using static Transversal.Helpers.RoutesPath;

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
                        .Include(a => a.PeliculasActores)
                            .ThenInclude(a => a.Actor)
                        .Include(a => a.PeliculasDirectores)
                            .ThenInclude(a => a.Director)
                        .Include(a => a.Genero)
                        .Include(a => a.Pais)
                        .ToListAsync();
        }

        public async Task<Pelicula> GetPeliculaById(long id)
        {
            var pelicula = await _context.Peliculas
                              .Include(a => a.PeliculasActores)
                                 .ThenInclude(a => a.Actor)
                              .Include(a => a.PeliculasDirectores)
                                .ThenInclude(a => a.Director)
                              .Include(a => a.Genero)
                              .Include(a => a.Pais)
                              .FirstOrDefaultAsync(a => a.PeliculaId == id);

            if (pelicula == null)
                throw new KeyNotFoundException($"No se encontró una pelicula con ID {id}.");

            return pelicula;
        }

        public async Task<bool> UpdatePelicula(long id, Pelicula pelicula)
        {
            var peliculaExistente = await _context.Peliculas
                .Include(a => a.PeliculasActores)
                    .ThenInclude(a => a.Actor)
                .Include(a => a.PeliculasDirectores)
                    .ThenInclude(a => a.Director)
                .FirstOrDefaultAsync(p => p.PeliculaId == id);

            if (peliculaExistente == null)
            {
                return false;
            }

            _context.Entry(peliculaExistente).CurrentValues.SetValues(pelicula);

            peliculaExistente.PeliculasDirectores.Clear();
            peliculaExistente.PeliculasActores.Clear();

            //var directoresIds = pelicula.PeliculasDirectores.Select(d => d.DirectorId).ToList();
            //var directores = await _context.PeliculasDirectores
            //    .Where(d => directoresIds.Contains(d.DirectorId))
            //    .ToListAsync();
            foreach (var director in pelicula.PeliculasDirectores)
            {
                peliculaExistente.PeliculasDirectores.Add(director);
            }

            //var actoresIds = pelicula.PeliculasActores.Select(d => d.ActorId).ToList();
            //var actores = await _context.Peliculas_Actores
            //    .Where(d => actoresIds.Contains(d.ActorId))
            //    .ToListAsync();
            foreach (var actor in pelicula.PeliculasActores)
            {
                peliculaExistente.PeliculasActores.Add(actor);
            }

            await _context.SaveChangesAsync();

            return true;
        }

        private bool PeliculaExists(long id)
        {
            return _context.Peliculas.Any(e => e.PeliculaId == id);
        }

        public async Task<CreatePeliculaDto> CreatePelicula(Pelicula pelicula)
        {
            pelicula.PeliculasDirectores = pelicula.PeliculasDirectores
                .Select(director =>
                {
                    var existingDirector = _context.Directores.Find(director.DirectorId);

                    if (existingDirector != null)
                    {
                        director.Director = existingDirector;
                    }
                    return director;
                })
                .ToList();

            pelicula.PeliculasActores = pelicula.PeliculasActores
                .Select(actor =>
                {
                    var existingActor = _context.Actores.Find(actor.ActorId);

                    if (existingActor != null)
                    {
                        actor.Actor = existingActor; 
                    }
                    return actor; 
                })
                .ToList();

            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();

            return new CreatePeliculaDto
            {
                PeliculaId = pelicula.PeliculaId,
                GeneroId = pelicula.GeneroId,
                PaisId = pelicula.PaisId,
                Titulo = pelicula.Titulo,
                Resena = pelicula.Resena,
                ImagenPortada = pelicula.ImagenPortada,
                CodigoTrailer = pelicula.CodigoTrailer
            };
        }


        public async Task<bool> DeletePelicula(long id)
        {
            var pelicula = await _context.Peliculas
                .FirstOrDefaultAsync(p => p.PeliculaId == id);

            if (pelicula == null)
            {
                return false;
            }

            pelicula.IsDeleted = true;

            var relacionesActores = _context.Peliculas_Actores
                .Where(pa => pa.PeliculaId == id)
                .ToList();

            foreach (var relacion in relacionesActores)
            {
                relacion.IsDeleted = true;
            }

            var relacionesDirectores = _context.PeliculasDirectores
                .Where(pd => pd.PeliculaId == id)
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
