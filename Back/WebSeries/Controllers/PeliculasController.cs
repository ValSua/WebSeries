using Aplication.Interface.Peliculas;
using Microsoft.AspNetCore.Mvc;
using Transversal.Dto.Generos;
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
    }
}
