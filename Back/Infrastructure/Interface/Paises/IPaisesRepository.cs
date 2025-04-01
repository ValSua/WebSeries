using Transversal.Dto.Paises;

using WebSeries.Models;

namespace Infrastructure.Interface.Paises
{
    public interface IPaisesRepository
    {
        Task<IEnumerable<Paise>> GetPaises();
        Task<Paise> GetPaisById(long id);
        Task<bool> UpdatePais(long id, Paise pais);
        Task<CreatePaisDto> CreatePais(Paise pais);
        Task<bool> DeletePais(long id);
    }
}
