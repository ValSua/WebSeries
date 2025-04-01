namespace Transversal.Dto.Generos
{
    public class GetGeneroDto
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

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }
    }
}
