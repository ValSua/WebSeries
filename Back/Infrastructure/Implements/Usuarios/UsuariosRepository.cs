﻿using Infrastructure.Interface.Usuarios;
using Microsoft.EntityFrameworkCore;
using WebSeries.Data;
using WebSeries.Models;

namespace Infrastructure.Implements.Usuarios
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly ProjectDbContext _context;

        public UsuariosRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios
                        .ToListAsync();
        }

        public bool ValidatePassword(long usuarioId, string passwordIngresado)
        {
            var usuario = _context.Usuarios
                                .FirstOrDefault(u => u.UsuarioId == usuarioId);

            if (usuario == null)
            {
                return false;
            }

            return usuario.Password == passwordIngresado;
        }
    }
}
