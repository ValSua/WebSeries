using Aplication.Interface.Directores;
using Infrastructure.Interface.Directores;
using Transversal.Dto.Actores;
using Transversal.Dto.Directores;
using WebSeries.Models;

namespace Aplication.Implements.Directores
{
    public class DirectoresService : IDirectoresService
    {
        private readonly IDirectoresRepository _directoresRepository;

        public DirectoresService(IDirectoresRepository directoresRepository)
        {
            _directoresRepository = directoresRepository;
        }

        public async Task<IEnumerable<GetDirectorDto>> GetDirectores()
        {
            var result = await _directoresRepository.GetDirectores();

            var directorMapped = AutoMapperConfig.GetMapper<Directore, GetDirectorDto>().Map<IEnumerable<GetDirectorDto>>(result);

            // Crear un diccionario para acceso rápido por DirectorId
            var directorDictionary = result.ToDictionary(a => a.DirectorId);

            // Asignar títulos de películas de manera eficiente
            foreach (var directorDto in directorMapped)
            {
                if (directorDictionary.TryGetValue(directorDto.DirectorId, out var directorOriginal))
                {
                    directorDto.PeliculasTitulo = directorOriginal.Peliculas.Select(p => p.Titulo).ToList();
                }
            }

            return directorMapped;
        }

        public async Task<GetDirectorDto> GetDirectorById(long id)
        {
            var result = await _directoresRepository.GetDirectorById(id);
            var directorMapped = AutoMapperConfig.GetMapper<Directore, GetDirectorDto>().Map<GetDirectorDto>(result);
            var peliculasTitulo = result.Peliculas.Select(p => p.Titulo).ToList();

            directorMapped.PeliculasTitulo = peliculasTitulo;

            return directorMapped;
        }

        public async Task<bool> UpdateDirector(long id, CreateDirectorDto updateDirectoreDto)
        {
            var directorMapped = AutoMapperConfig.GetMapper<CreateDirectorDto, Directore>().Map<Directore>(updateDirectoreDto);
            directorMapped.DirectorId = id;

            var result = await _directoresRepository.UpdateDirector(id, directorMapped);
            return result;
        }

        public async Task<CreateDirectorDto> CreateDirector(CreateDirectorDto createDirectoreDto)
        {
            var directorMapped = AutoMapperConfig.GetMapper<CreateDirectorDto, Directore>().Map<Directore>(createDirectoreDto);

            var result = await _directoresRepository.CreateDirector(directorMapped);


            return result;
        }

        public async Task<bool> DeleteDirector(long id)
        {
            var result = await _directoresRepository.DeleteDirector(id);
            return result;
        }
    }
}
