using WebSeries.Models;

namespace Infrastructure.Interface
{
    public interface IActoresRepository
    {
        Task<IEnumerable<Actore>> GetActores();
        Task<Actore> GetActorById(long id);
    }
}
