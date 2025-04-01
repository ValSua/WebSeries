using Transversal.Dto.Peliculas;
using WebSeries.Models;

namespace Infrastructure.Interface.Peliculas
{
    public interface IPeliculasRepository
    {
        Task<IEnumerable<Pelicula>> GetPeliculas();
        Task<Pelicula> GetPeliculaById(long id);
        Task<bool> UpdatePelicula(long id, Pelicula pelicula);
        Task<CreatePeliculaDto> CreatePelicula(Pelicula pelicula);
        Task<bool> DeletePelicula(long id);
    }
}
