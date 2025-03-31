using Transversal.Dto;
using WebSeries.Models;

namespace Infrastructure.Interface
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
