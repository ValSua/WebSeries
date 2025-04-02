using Transversal.Dto.Generos;
using WebSeries.Models;

namespace Infrastructure.Interface.Generos
{
    public interface IGenerosRepository
    {
        Task<IEnumerable<Genero>> GetGeneros();
        Task<Genero> GetGeneroById(long id);
        Task<bool> UpdateGenero(long id, Genero genero);
        Task<CreateGeneroDto> CreateGenero(Genero genero);
        Task<bool> DeleteGenero(long id);
    }
}
