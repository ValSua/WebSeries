﻿using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Transversal.Dto;
using WebSeries.Data;
using WebSeries.Models;

namespace Infrastructure.Implements
{
    public class ActoresRepository : IActoresRepository
    {
        private readonly ProjectDbContext _context;

        public ActoresRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actore>> GetActores()
        {
            return await _context.Actores
                        .Where(a => !a.IsDeleted)
                        .Include(a => a.Pais)
                        .Include(a => a.Peliculas)
                        .ToListAsync();
        }

        public async Task<Actore> GetActorById(long id)
        {
            var actor = await _context.Actores
                              .Include(a => a.Pais)
                              .Include(a => a.Peliculas)
                              .FirstOrDefaultAsync(a => a.ActorId == id);

            if (actor == null)
                throw new KeyNotFoundException($"No se encontró un actor con ID {id}.");

            return actor;
        }

        public async Task<bool> UpdateActor(long id, Actore actore)
        {
            if (id != actore.ActorId)
            {
                return false;
            }

            _context.Entry(actore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActoreExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private bool ActoreExists(long id)
        {
            return _context.Actores.Any(e => e.ActorId == id);
        }

        public async Task<CreateActorDto> CreateActor(Actore actore)
        {
            _context.Actores.Add(actore);
            await _context.SaveChangesAsync();

            return new CreateActorDto
            {
                ActorId = actore.ActorId,  
                Nombre = actore.Nombre,
                Apellido = actore.Apellido,
                PaisId = actore.PaisId
            };
        }

        public async Task<bool> DeleteActor(long id)
        {
            var actor = await _context.Actores.FindAsync(id);
            if (actor == null)
            {
                return false;
            }

            actor.IsDeleted = true;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
