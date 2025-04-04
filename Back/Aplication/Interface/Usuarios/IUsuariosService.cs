using Transversal.Dto.Usuarios;

namespace Aplication.Interface.Usuarios
{
    public interface IUsuariosService
    {
        Task<IEnumerable<GetUsuarioDto>> GetUsuarios();
    }
}
