using Transversal.Dto.Peliculas;

namespace Aplication.Interface.Peliculas
{
    public interface IPeliculasService
    {
        Task<IEnumerable<GetPeliculaDto>> GetPeliculas();
        Task<GetPeliculaDto> GetPeliculaById(long id);
        Task<bool> UpdatePelicula(long id, CreatePeliculaDto updatePeliculaDto);
        Task<CreatePeliculaDto> CreatePelicula(CreatePeliculaDto createPeliculaDto);
        Task<bool> DeletePelicula(long id);
    }
}
