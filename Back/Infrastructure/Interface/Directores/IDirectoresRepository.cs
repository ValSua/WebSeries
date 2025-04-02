using Transversal.Dto.Directores;
using WebSeries.Models;

namespace Infrastructure.Interface.Directores
{
    public interface IDirectoresRepository
    {
        Task<IEnumerable<Directore>> GetDirectores();
        Task<Directore> GetDirectorById(long id);
        Task<bool> UpdateDirector(long id, Directore directore);
        Task<CreateDirectorDto> CreateDirector(Directore directore);
        Task<bool> DeleteDirector(long id);
    }
}
