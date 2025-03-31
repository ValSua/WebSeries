using Transversal.Dto;

namespace Aplication.Interface
{
    public interface IActoresService
    {

        Task<IEnumerable<GetActorDto>> GetActores();
        Task<GetActorDto> GetActorById(long id);
        Task<bool> UpdateActor(long id, CreateActorDto updateActoreDto);
        Task<CreateActorDto> CreateActor(CreateActorDto createActoreDto);
        Task<bool> DeleteActor(long id);
    }
}
