using Aplication.Interface.Generos;
using Microsoft.AspNetCore.Mvc;
using Transversal.Dto.Generos;
using Transversal.Helpers;

namespace WebSeries.Controllers
{
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// The generos service
        /// </summary>
        private readonly IGenerosService _generosService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerosController"/> class.
        /// </summary>
        /// <param name="generosService">The generos service.</param>
        public GenerosController(IGenerosService generosService)
        {
            _generosService = generosService;
        }

        /// <summary>
        /// Gets the generos.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPath.Generos.GetGeneros)]
        public async Task<IEnumerable<GetGeneroDto>> GetGeneros() => await _generosService.GetGeneros();

        /// <summary>
        /// Gets the genero by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet(RoutesPath.Generos.GetGeneroById)]
        public async Task<GetGeneroDto> GetGeneroById(long id) => await _generosService.GetGeneroById(id);

        /// <summary>
        /// Updates the genero.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="genero">The genero.</param>
        /// <returns></returns>
        [HttpPut(RoutesPath.Generos.UpdateGenero)]
        public async Task<bool> UpdateGenero(long id, CreateGeneroDto updateGeneroDto) => await _generosService.UpdateGenero(id, updateGeneroDto);

        /// <summary>
        /// Creates the genero.
        /// </summary>
        /// <param name="createActoreDto">The create genero dto.</param>
        /// <returns></returns>
        [HttpPost(RoutesPath.Generos.CreateGenero)]
        public async Task<CreateGeneroDto> CreateGenero(CreateGeneroDto createGeneroDto) => await _generosService.CreateGenero(createGeneroDto);

        /// <summary>
        /// Deletes the genero.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut(RoutesPath.Generos.DeleteGenero)]
        public async Task<bool> DeleteGenero(long id) => await _generosService.DeleteGenero(id);
    }
}