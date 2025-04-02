using Aplication.Interface.Generos;
using Infrastructure.Interface.Generos;
using Transversal.Dto.Generos;
using WebSeries.Models;

namespace Aplication.Implements.Generos
{
    public class GenerosService : IGenerosService
    {
        private readonly IGenerosRepository _generosRepository;

        public GenerosService(IGenerosRepository generosRepository)
        {
            _generosRepository = generosRepository;
        }

        public async Task<IEnumerable<GetGeneroDto>> GetGeneros()
        {
            var result = await _generosRepository.GetGeneros();

            var generoMapped = AutoMapperConfig.GetMapper<Genero, GetGeneroDto>().Map<IEnumerable<GetGeneroDto>>(result);

            return generoMapped;
        }

        public async Task<GetGeneroDto> GetGeneroById(long id)
        {
            var result = await _generosRepository.GetGeneroById(id);
            var generoMapped = AutoMapperConfig.GetMapper<Genero, GetGeneroDto>().Map<GetGeneroDto>(result);

            return generoMapped;
        }

        public async Task<bool> UpdateGenero(long id, CreateGeneroDto updateGeneroDto)
        {
            var generoMapped = AutoMapperConfig.GetMapper<CreateGeneroDto, Genero>().Map<Genero>(updateGeneroDto);
            generoMapped.GeneroId = id;

            var result = await _generosRepository.UpdateGenero(id, generoMapped);
            return result;
        }

        public async Task<CreateGeneroDto> CreateGenero(CreateGeneroDto createGeneroDto)
        {
            var generoMapped = AutoMapperConfig.GetMapper<CreateGeneroDto, Genero>().Map<Genero>(createGeneroDto);

            var result = await _generosRepository.CreateGenero(generoMapped);

            return result;
        }

        public async Task<bool> DeleteGenero(long id)
        {
            var result = await _generosRepository.DeleteGenero(id);
            return result;
        }
    }
}
