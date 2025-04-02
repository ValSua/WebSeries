using Transversal.Dto.Actores;
using WebSeries.Models;

namespace Infrastructure.Interface.Actores
{
    public interface IActoresRepository
    {
        Task<IEnumerable<Actore>> GetActores();
        Task<Actore> GetActorById(long id);
        Task<bool> UpdateActor(long id, Actore actore);
        Task<CreateActorDto> CreateActor(Actore actore);
        Task<bool> DeleteActor(long id);
    }
}
