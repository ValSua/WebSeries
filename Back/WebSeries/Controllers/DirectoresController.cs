using Aplication.Interface.Directores;
using Microsoft.AspNetCore.Mvc;
using Transversal.Dto.Actores;
using Transversal.Dto.Directores;
using Transversal.Helpers;

namespace WebSeries.Controllers
{
    [ApiController]
    public class DirectoresController : ControllerBase
    {
        // <summary>
        /// The directores service
        /// </summary>
        private readonly IDirectoresService _directoresService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoresController"/> class.
        /// </summary>
        /// <param name="directoresService">The directores service.</param>
        public DirectoresController(IDirectoresService directoresService)
        {
            _directoresService = directoresService;
        }

        /// <summary>
        /// Gets the directores.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPath.Directores.GetDirectores)]
        public async Task<IEnumerable<GetDirectorDto>> GetDirectores() => await _directoresService.GetDirectores();

        /// <summary>
        /// Gets the director by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet(RoutesPath.Directores.GetDirectorById)]
        public async Task<GetDirectorDto> GetDirectorById(long id) => await _directoresService.GetDirectorById(id);

        /// <summary>
        /// Updates the director.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="directore">The directore.</param>
        /// <returns></returns>
        [HttpPut(RoutesPath.Directores.UpdateDirector)]
        public async Task<bool> UpdateDirector(long id, CreateDirectorDto updateDirectoreDto) => await _directoresService.UpdateDirector(id, updateDirectoreDto);

        /// <summary>
        /// Creates the director.
        /// </summary>
        /// <param name="createDirectoreDto">The create directore dto.</param>
        /// <returns></returns>
        [HttpPost(RoutesPath.Directores.CreateDirector)]
        public async Task<CreateDirectorDto> CreateDirector(CreateDirectorDto createDirectoreDto) => await _directoresService.CreateDirector(createDirectoreDto);

        /// <summary>
        /// Deletes the actor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut(RoutesPath.Directores.DeleteDirector)]
        public async Task<bool> DeleteDirector(long id) => await _directoresService.DeleteDirector(id);
    }
}
