using Transversal.Dto.Peliculas;
using WebSeries.Models;

namespace Infrastructure.Interface.Peliculas
{
    public interface IPeliculasRepository
    {
        Task<IEnumerable<Pelicula>> GetPeliculas();
        Task<Pelicula> GetPeliculaById(long id);
    }
}
