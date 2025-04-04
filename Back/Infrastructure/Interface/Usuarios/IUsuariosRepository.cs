using WebSeries.Models;

namespace Infrastructure.Interface.Usuarios
{
    public interface IUsuariosRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
    }
}
