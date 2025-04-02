using Transversal.Dto.Actores;
using Transversal.Dto.Directores;

namespace Aplication.Interface.Directores
{
    public interface IDirectoresService
    {
        Task<IEnumerable<GetDirectorDto>> GetDirectores();
        Task<GetDirectorDto> GetDirectorById(long id);
        Task<bool> UpdateDirector(long id, CreateDirectorDto updateDirectoreDto);
        Task<CreateDirectorDto> CreateDirector(CreateDirectorDto createDirectoreDto);
        Task<bool> DeleteDirector(long id);
    }
}
