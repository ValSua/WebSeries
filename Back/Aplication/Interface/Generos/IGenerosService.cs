using Transversal.Dto.Generos;

namespace Aplication.Interface.Generos
{
    public interface IGenerosService
    {
        Task<IEnumerable<GetGeneroDto>> GetGeneros();
        Task<GetGeneroDto> GetGeneroById(long id);
        Task<bool> UpdateGenero(long id, CreateGeneroDto updateGeneroDto);
        Task<CreateGeneroDto> CreateGenero(CreateGeneroDto createGeneroDto);
        Task<bool> DeleteGenero(long id);

    }
}
