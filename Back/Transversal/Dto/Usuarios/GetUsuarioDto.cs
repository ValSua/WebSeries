﻿namespace Transversal.Dto.Usuarios
{
    public class GetUsuarioDto
    {
        /// <summary>
        /// Gets or sets the usuario identifier.
        /// </summary>
        /// <value>
        /// The usuario identifier.
        /// </value>
        public long UsuarioId { get; set; }
        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        /// <value>
        /// The login.
        /// </value>
        public string Login { get; set; } = null!;
    }
}
