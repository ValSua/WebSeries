namespace Transversal.Dto.Generos
{
    public class CreateGeneroDto
    {
        /// <summary>
        /// Gets or sets the genero identifier.
        /// </summary>
        /// <value>
        /// The genero identifier.
        /// </value>
        public long GeneroId { get; set; }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string Nombre { get; set; } = null!;
    }
}
