using Aplication.Interface.Peliculas;
using AutoMapper;
using Infrastructure.Interface.Directores;
using Infrastructure.Interface.Peliculas;
using Transversal.Dto.Peliculas;
using WebSeries.Models;

namespace Aplication.Implements.Peliculas
{
    public class PeliculasService : IPeliculasService
    {
        private readonly IPeliculasRepository _peliculasRepository;
        private readonly IDirectoresRepository _directoresRepository;

        public PeliculasService(IPeliculasRepository peliculasRepository, IDirectoresRepository directoresRepository)
        {
            _peliculasRepository = peliculasRepository;
            _directoresRepository = directoresRepository;
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
                    peliculaDto.Actors = peliculaOriginal.PeliculasActores.Select(p => p.Actor.ActorId).ToList();
                    peliculaDto.Directors = peliculaOriginal.PeliculasDirectores.Select(p => p.Director.DirectorId).ToList();

                }
            }

            return peliculaMapped;
        }

        public async Task<GetPeliculaDto> GetPeliculaById(long id)
        {
            var result = await _peliculasRepository.GetPeliculaById(id);
            var peliculaMapped = AutoMapperConfig.GetMapper<Pelicula, GetPeliculaDto>().Map<GetPeliculaDto>(result);

            //var actores = result.PeliculasActores.Select(p => p.Actor.Nombre + " " + p.Actor.Apellido).ToList();
            var actores = result.PeliculasActores.Select(p => p.Actor.ActorId).ToList();
            var directores = result.PeliculasDirectores.Select(p => p.Director.DirectorId).ToList();

            peliculaMapped.Actors = actores;
            peliculaMapped.Directors = directores;

            return peliculaMapped;
        }

        public async Task<bool> UpdatePelicula(long id, CreatePeliculaDto updatePeliculaDto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreatePeliculaDto, Pelicula>()
                    .ForMember(dest => dest.PeliculasDirectores, opt => opt.Ignore())
                    .ForMember(dest => dest.PeliculasActores, opt => opt.Ignore());
            });

            var specialMapper = config.CreateMapper();

            var peliculaMapped = specialMapper.Map<Pelicula>(updatePeliculaDto);
            peliculaMapped.PeliculaId = id;

            //peliculaMapped.PeliculasActores = updatePeliculaDto.Actors
            //    .Select(actorId => new PeliculasActore { ActorId = actorId }) 
            //    .ToList();

            //peliculaMapped.PeliculasDirectores = updatePeliculaDto.Directors
            //    .Select(directorId => new PeliculasDirectore { DirectorId = directorId })
            //    .ToList();

            return await _peliculasRepository.UpdatePelicula(id, peliculaMapped);
        }

        public async Task<CreatePeliculaDto> CreatePelicula(CreatePeliculaDto createPeliculaDto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreatePeliculaDto, Pelicula>()
                    .ForMember(dest => dest.PeliculasDirectores, opt => opt.Ignore())
                    .ForMember(dest => dest.PeliculasActores, opt => opt.Ignore());
            });

            var specialMapper = config.CreateMapper();

            var peliculaMapped = specialMapper.Map<Pelicula>(createPeliculaDto);

            peliculaMapped.PeliculasActores = createPeliculaDto.Actors
                .Select(actorId => new PeliculasActore { ActorId = actorId })
                .ToList();

            peliculaMapped.PeliculasDirectores = createPeliculaDto.Directors
                .Select(directorId => new PeliculasDirectore { DirectorId = directorId })
                .ToList();

            var result = await _peliculasRepository.CreatePelicula(peliculaMapped);

            return result;
        }


        public async Task<bool> DeletePelicula(long id)
        {
            var result = await _peliculasRepository.DeletePelicula(id);
            return result;
        }
    }
}
