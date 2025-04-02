using Aplication.Interface.Paises;
using Microsoft.AspNetCore.Mvc;
using Transversal.Dto.Paises;
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
        public async Task<IEnumerable<GetPaisDto>> GetPaises() => await _paisesService.GetPaises();

        /// <summary>
        /// Gets the pais by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet(RoutesPath.Paises.GetPaisById)]
        public async Task<GetPaisDto> GetPaisById(long id) => await _paisesService.GetPaisById(id);

        /// <summary>
        /// Updates the pais.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="pais">The pais.</param>
        /// <returns></returns>
        [HttpPut(RoutesPath.Paises.UpdatePais)]
        public async Task<bool> UpdatePais(long id, CreatePaisDto updatePaisDto) => await _paisesService.UpdatePais(id, updatePaisDto);

        /// <summary>
        /// Creates the pais.
        /// </summary>
        /// <param name="createActoreDto">The create pais dto.</param>
        /// <returns></returns>
        [HttpPost(RoutesPath.Paises.CreatePais)]
        public async Task<CreatePaisDto> CreatePais(CreatePaisDto createPaisDto) => await _paisesService.CreatePais(createPaisDto);

        /// <summary>
        /// Deletes the pais.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut(RoutesPath.Paises.DeletePais)]
        public async Task<bool> DeletePais(long id) => await _paisesService.DeletePais(id);
    }
}
