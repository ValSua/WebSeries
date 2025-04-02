using Aplication.Interface.Peliculas;
using Microsoft.AspNetCore.Mvc;
using Transversal.Dto.Peliculas;
using Transversal.Helpers;

namespace WebSeries.Controllers
{
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        /// <summary>
        /// The peliculas service
        /// </summary>
        private readonly IPeliculasService _peliculasService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeliculasController"/> class.
        /// </summary>
        /// <param name="peliculasService">The peliculas service.</param>
        public PeliculasController(IPeliculasService peliculasService)
        {
            _peliculasService = peliculasService;
        }

        /// <summary>
        /// Gets the peliculas.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPath.Peliculas.GetPeliculas)]
        public async Task<IEnumerable<GetPeliculaDto>> GetPeliculas() => await _peliculasService.GetPeliculas();

        /// <summary>
        /// Gets the pelicula by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet(RoutesPath.Peliculas.GetPeliculaById)]
        public async Task<GetPeliculaDto> GetPeliculaById(long id) => await _peliculasService.GetPeliculaById(id);

        /// <summary>
        /// Updates the pelicula.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="updatePeliculaDto">The update pelicula dto.</param>
        /// <returns></returns>
        [HttpPut(RoutesPath.Peliculas.UpdatePelicula)]
        public async Task<bool> UpdatePelicula(long id, CreatePeliculaDto updatePeliculaDto) => await _peliculasService.UpdatePelicula(id, updatePeliculaDto);

        /// <summary>
        /// Creates the pelicula.
        /// </summary>
        /// <param name="createPeliculaDto">The create pelicula dto.</param>
        /// <returns></returns>
        [HttpPost(RoutesPath.Peliculas.CreatePelicula)]
        public async Task<CreatePeliculaDto> CreatePelicula(CreatePeliculaDto createPeliculaDto) => await _peliculasService.CreatePelicula(createPeliculaDto);

        /// <summary>
        /// Deletes the pelicula.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut(RoutesPath.Peliculas.DeletePelicula)]
        public async Task<bool> DeletePelicula(long id) => await _peliculasService.DeletePelicula(id);
    }
}
