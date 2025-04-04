using Aplication.Interface.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Transversal.Dto.Actores;
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

        /// <summary>
        /// Validates the password.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        [HttpGet(RoutesPath.Usuarios.ValidatePassword)]
        public bool ValidatePassword(long id, string password) => _usuariosService.ValidatePassword(id, password);
    }
}
