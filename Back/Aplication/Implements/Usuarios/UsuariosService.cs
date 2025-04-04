using Aplication.Interface.Usuarios;
using Infrastructure.Interface.Usuarios;
using Transversal.Dto.Usuarios;
using WebSeries.Models;

namespace Aplication.Implements.Usuarios
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosService(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public async Task<IEnumerable<GetUsuarioDto>> GetUsuarios()
        {
            var result = await _usuariosRepository.GetUsuarios();

            var usuarioMapped = AutoMapperConfig.GetMapper<Usuario, GetUsuarioDto>().Map<IEnumerable<GetUsuarioDto>>(result);

            return usuarioMapped;
        }

        public bool ValidatePassword(long id, string password)
        {
            var result = _usuariosRepository.ValidatePassword(id, password);

            return result;
        }
    }
}
