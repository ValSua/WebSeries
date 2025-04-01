using Microsoft.AspNetCore.Mvc;
using Transversal.Helpers;

namespace WebSeries.Controllers
{
    [ApiController]
    public class PaisesController : ControllerBase
    {
        /// <summary>
        /// The paises service
        /// </summary>
        private readonly IPaisesService _paisesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaisesController"/> class.
        /// </summary>
        /// <param name="paisesService">The paises service.</param>
        public PaisesController(IPaisesService paisesService)
        {
            _paisesService = paisesService;
        }

        /// <summary>
        /// Gets the paises.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPath.Paises.GetPaises)]
        public async Task<IEnumerable<GetGeneroDto>> GetPaises() => await _paisesService.GetPaises();

        /// <summary>
        /// Gets the pais by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet(RoutesPath.Paises.GetGeneroById)]
        public async Task<GetGeneroDto> GetGeneroById(long id) => await _paisesService.GetGeneroById(id);

        /// <summary>
        /// Updates the pais.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="pais">The pais.</param>
        /// <returns></returns>
        [HttpPut(RoutesPath.Paises.UpdateGenero)]
        public async Task<bool> UpdateGenero(long id, CreateGeneroDto updateGeneroDto) => await _paisesService.UpdateGenero(id, updateGeneroDto);

        /// <summary>
        /// Creates the pais.
        /// </summary>
        /// <param name="createActoreDto">The create pais dto.</param>
        /// <returns></returns>
        [HttpPost(RoutesPath.Paises.CreateGenero)]
        public async Task<CreateGeneroDto> CreateGenero(CreateGeneroDto createGeneroDto) => await _paisesService.CreateGenero(createGeneroDto);

        /// <summary>
        /// Deletes the pais.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut(RoutesPath.Paises.DeleteGenero)]
        public async Task<bool> DeleteGenero(long id) => await _paisesService.DeleteGenero(id);
    }
}
