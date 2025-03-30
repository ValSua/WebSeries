using Aplication.Interface;
using Infrastructure.Interface;
using WebSeries.Models;

namespace Aplication.Implements
{
    public class ActoresService : IActoresService
    {
        private readonly IActoresRepository _actoresRepository;

        public ActoresService(IActoresRepository actoresRepository)
        {
            _actoresRepository = actoresRepository;
        }

        public async Task<IEnumerable<Actore>> GetActores()
        {
            var result = await _actoresRepository.GetActores();
            return result;
        }

        public async Task<Actore> GetActorById(long id)
        {
            var result = await _actoresRepository.GetActorById(id);
            return result;
        }
    }
}
