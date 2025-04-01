using Aplication.Interface.Peliculas;
using Infrastructure.Interface.Peliculas;
using Transversal.Dto.Actores;
using Transversal.Dto.Peliculas;
using WebSeries.Models;

namespace Aplication.Implements.Peliculas
{
    public class PeliculasService : IPeliculasService
    {
        private readonly IPeliculasRepository _peliculasRepository;

        public PeliculasService(IPeliculasRepository peliculasRepository)
        {
            _peliculasRepository = peliculasRepository;
        }

        public async Task<IEnumerable<GetPeliculaDto>> GetPeliculas()
        {
            var result = await _peliculasRepository.GetPeliculas();

            var peliculaMapped = AutoMapperConfig.GetMapper<Pelicula, GetPeliculaDto>().Map<IEnumerable<GetPeliculaDto>>(result);

            var peliculaDictionary = result.ToDictionary(a => a.PeliculaId);

            foreach (var peliculaDto in peliculaMapped)
            {
                if (peliculaDictionary.TryGetValue(peliculaDto.PeliculaId, out var peliculaOriginal))
                {
                    peliculaDto.Actors = peliculaOriginal.Actors.Select(p => p.Nombre +" "+ p.Apellido).ToList();
                    peliculaDto.Directors = peliculaOriginal.Directors.Select(p => p.Nombre + " " + p.Apellido).ToList();

                }
            }

            return peliculaMapped;
        }

        public async Task<GetPeliculaDto> GetPeliculaById(long id)
        {
            var result = await _peliculasRepository.GetPeliculaById(id);
            var peliculaMapped = AutoMapperConfig.GetMapper<Pelicula, GetPeliculaDto>().Map<GetPeliculaDto>(result);

            var actores = result.Actors.Select(p => p.Nombre +" "+ p.Apellido).ToList();
            var directores = result.Directors.Select(p => p.Nombre + " " + p.Apellido).ToList();

            peliculaMapped.Actors = actores;
            peliculaMapped.Directors = directores;

            return peliculaMapped;
        }
    }
}
