namespace Transversal.Dto.Paises
{
    public class GetPaisDto
    {
        /// <summary>
        /// Gets or sets the pais identifier.
        /// </summary>
        /// <value>
        /// The pais identifier.
        /// </value>
        public long PaisId { get; set; }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string Nombre { get; set; } = null!;

    }
}
