using Transversal.Dto.Peliculas;

namespace Aplication.Interface.Peliculas
{
    public interface IPeliculasService
    {
        Task<IEnumerable<GetPeliculaDto>> GetPeliculas();
        Task<GetPeliculaDto> GetPeliculaById(long id);
    }
}
