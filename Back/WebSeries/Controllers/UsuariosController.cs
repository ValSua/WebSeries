using Aplication.Interface.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Transversal.Dto.Usuarios;
using Transversal.Helpers;

namespace WebSeries.Controllers
{
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// The usuarios service
        /// </summary>
        private readonly IUsuariosService _usuariosService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsuariosController"/> class.
        /// </summary>
        /// <param name="usuariosService">The usuarios service.</param>
        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        /// <summary>
        /// Gets the usuarios.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPath.Usuarios.GetUsuarios)]
        public async Task<IEnumerable<GetUsuarioDto>> GetUsuarios() => await _usuariosService.GetUsuarios();
    }
}
