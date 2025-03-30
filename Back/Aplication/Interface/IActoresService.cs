using WebSeries.Models;

namespace Aplication.Interface
{
    public interface IActoresService
    {
        Task<IEnumerable<Actore>> GetActores();
        Task<Actore> GetActorById(long id);
    }
}
