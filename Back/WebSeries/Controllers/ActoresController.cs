using Aplication.Interface;
using Microsoft.AspNetCore.Mvc;
using Transversal.Dto;
using Transversal.Helpers;

namespace WebSeries.Controllers
{
    [ApiController]
    public class ActoresController : ControllerBase
    {
        /// <summary>
        /// The actores service
        /// </summary>
        private readonly IActoresService _actoresService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActoresController"/> class.
        /// </summary>
        /// <param name="actoresService">The actores service.</param>
        public ActoresController(IActoresService actoresService)
        {
            _actoresService = actoresService;
        }

        /// <summary>
        /// Gets the actores.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPath.Actores.GetActores)]
        public async Task<IEnumerable<GetActorDto>> GetActores() => await _actoresService.GetActores();

        /// <summary>
        /// Gets the actor by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet(RoutesPath.Actores.GetActorById)]
        public async Task<GetActorDto> GetActorById(long id) => await _actoresService.GetActorById(id);

        /// <summary>
        /// Updates the actor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="actore">The actore.</param>
        /// <returns></returns>
        [HttpPut(RoutesPath.Actores.UpdateActor)]
        public async Task<bool> UpdateActor(long id, CreateActorDto updateActoreDto) => await _actoresService.UpdateActor(id, updateActoreDto);

        /// <summary>
        /// Creates the actor.
        /// </summary>
        /// <param name="createActoreDto">The create actore dto.</param>
        /// <returns></returns>
        [HttpPost(RoutesPath.Actores.CreateActor)]
        public async Task<CreateActorDto> CreateActor(CreateActorDto createActoreDto) => await _actoresService.CreateActor(createActoreDto);

        /// <summary>
        /// Deletes the actor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost(RoutesPath.Actores.DeleteActor)]
        public async Task<bool> DeleteActor(long id) => await _actoresService.DeleteActor(id);

    }
}
