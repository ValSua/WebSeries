using System.ComponentModel.DataAnnotations.Schema;

namespace Transversal.Dto
{
    public class GetActorDto
    {
        /// <summary>
        /// Gets or sets the actor identifier.
        /// </summary>
        /// <value>
        /// The actor identifier.
        /// </value>
        public long ActorId { get; set; }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string Nombre { get; set; } = null!;

        /// <summary>
        /// Gets or sets the apellido.
        /// </summary>
        /// <value>
        /// The apellido.
        /// </value>
        public string Apellido { get; set; } = null!;

        /// <summary>
        /// Gets or sets the pais identifier.
        /// </summary>
        /// <value>
        /// The pais identifier.
        /// </value>
        public long PaisId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the pais nombre.
        /// </summary>
        /// <value>
        /// The pais nombre.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string PaisNombre { get; set; } = null!;

        /// <summary>
        /// Gets or sets the peliculas titulo.
        /// </summary>
        /// <value>
        /// The peliculas titulo.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public List<string> PeliculasTitulo { get; set; } = new List<string>();
    }
}
