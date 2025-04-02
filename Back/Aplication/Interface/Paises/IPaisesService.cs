using Transversal.Dto.Paises;

namespace Aplication.Interface.Paises
{
    public interface IPaisesService
    {
        Task<IEnumerable<GetPaisDto>> GetPaises();
        Task<GetPaisDto> GetPaisById(long id);
        Task<bool> UpdatePais(long id, CreatePaisDto updatePaisDto);
        Task<CreatePaisDto> CreatePais(CreatePaisDto createPaisDto);
        Task<bool> DeletePais(long id);
    }
}
