using Aplication.Interface.Actores;
using Infrastructure.Interface.Actores;
using Transversal.Dto.Actores;
using WebSeries.Models;

namespace Aplication.Implements.Actores
{
    public class ActoresService : IActoresService
    {
        private readonly IActoresRepository _actoresRepository;

        public ActoresService(IActoresRepository actoresRepository)
        {
            _actoresRepository = actoresRepository;
        }

        public async Task<IEnumerable<GetActorDto>> GetActores()
        {
            var result = await _actoresRepository.GetActores();

            var actorMapped = AutoMapperConfig.GetMapper<Actore, GetActorDto>().Map<IEnumerable<GetActorDto>>(result);

            // Crear un diccionario para acceso rápido por ActorId
            var actorDictionary = result.ToDictionary(a => a.ActorId);

            // Asignar títulos de películas de manera eficiente
            foreach (var actorDto in actorMapped)
            {
                if (actorDictionary.TryGetValue(actorDto.ActorId, out var actorOriginal))
                {
                    actorDto.PeliculasTitulo = actorOriginal.Peliculas.Select(p => p.Titulo).ToList();
                }
            }

            return actorMapped;
        }

        public async Task<GetActorDto> GetActorById(long id)
        {
            var result = await _actoresRepository.GetActorById(id);
            var actorMapped = AutoMapperConfig.GetMapper<Actore, GetActorDto>().Map<GetActorDto>(result);
            var peliculasTitulo = result.Peliculas.Select(p => p.Titulo).ToList();

            actorMapped.PeliculasTitulo = peliculasTitulo;

            return actorMapped;
        }

        public async Task<bool> UpdateActor(long id, CreateActorDto updateActoreDto)
        {
            var actorMapped = AutoMapperConfig.GetMapper<CreateActorDto, Actore>().Map<Actore>(updateActoreDto);
            actorMapped.ActorId = id;

            var result = await _actoresRepository.UpdateActor(id, actorMapped);
            return result;
        }

        public async Task<CreateActorDto> CreateActor(CreateActorDto createActoreDto)
        {
            var actorMapped = AutoMapperConfig.GetMapper<CreateActorDto, Actore>().Map<Actore>(createActoreDto);

            var result = await _actoresRepository.CreateActor(actorMapped);


            return result;
        }

        public async Task<bool> DeleteActor(long id)
        {
            var result = await _actoresRepository.DeleteActor(id);
            return result;
        }
    }
}
