using Aplication.Interface.Paises;
using Infrastructure.Interface.Paises;
using Transversal.Dto.Paises;
using WebSeries.Models;

namespace Aplication.Implements.Paises
{
    public class PaisesService : IPaisesService
    {
        private readonly IPaisesRepository _paisesRepository;

        public PaisesService(IPaisesRepository paisesRepository)
        {
            _paisesRepository = paisesRepository;
        }

        public async Task<IEnumerable<GetPaisDto>> GetPaises()
        {
            var result = await _paisesRepository.GetPaises();

            var paisMapped = AutoMapperConfig.GetMapper<Paise, GetPaisDto>().Map<IEnumerable<GetPaisDto>>(result);

            return paisMapped;
        }

        public async Task<GetPaisDto> GetPaisById(long id)
        {
            var result = await _paisesRepository.GetPaisById(id);
            var paisMapped = AutoMapperConfig.GetMapper<Paise, GetPaisDto>().Map<GetPaisDto>(result);

            return paisMapped;
        }

        public async Task<bool> UpdatePais(long id, CreatePaisDto updatePaisDto)
        {
            var paisMapped = AutoMapperConfig.GetMapper<CreatePaisDto, Paise>().Map<Paise>(updatePaisDto);
            paisMapped.PaisId = id;

            var result = await _paisesRepository.UpdatePais(id, paisMapped);
            return result;
        }

        public async Task<CreatePaisDto> CreatePais(CreatePaisDto createPaisDto)
        {
            var paisMapped = AutoMapperConfig.GetMapper<CreatePaisDto, Paise>().Map<Paise>(createPaisDto);

            var result = await _paisesRepository.CreatePais(paisMapped);

            return result;
        }

        public async Task<bool> DeletePais(long id)
        {
            var result = await _paisesRepository.DeletePais(id);
            return result;
        }
    }
}
