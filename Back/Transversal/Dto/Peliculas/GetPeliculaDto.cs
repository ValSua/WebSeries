using System.ComponentModel.DataAnnotations.Schema;

namespace Transversal.Dto.Peliculas
{
    public class GetPeliculaDto
    {
        /// <summary>
        /// Gets or sets the pelicula identifier.
        /// </summary>
        /// <value>
        /// The pelicula identifier.
        /// </value>
        public long PeliculaId { get; set; }

        /// <summary>
        /// Gets or sets the genero identifier.
        /// </summary>
        /// <value>
        /// The genero identifier.
        /// </value>
        public long GeneroId { get; set; }

        /// <summary>
        /// Gets or sets the genero nombre.
        /// </summary>
        /// <value>
        /// The genero nombre.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string GeneroNombre { get; set; } = null!;

        /// <summary>
        /// Gets or sets the pais identifier.
        /// </summary>
        /// <value>
        /// The pais identifier.
        /// </value>
        public long PaisId { get; set; }

        /// <summary>
        /// Gets or sets the pais nombre.
        /// </summary>
        /// <value>
        /// The pais nombre.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string PaisNombre { get; set; } = null!;

        /// <summary>
        /// Gets or sets the titulo.
        /// </summary>
        /// <value>
        /// The titulo.
        /// </value>
        public string Titulo { get; set; } = null!;

        /// <summary>
        /// Gets or sets the resena.
        /// </summary>
        /// <value>
        /// The resena.
        /// </value>
        public string? Resena { get; set; }

        /// <summary>
        /// Gets or sets the imagen portada.
        /// </summary>
        /// <value>
        /// The imagen portada.
        /// </value>
        public string? ImagenPortada { get; set; }

        /// <summary>
        /// Gets or sets the codigo trailer.
        /// </summary>
        /// <value>
        /// The codigo trailer.
        /// </value>
        public string? CodigoTrailer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the directors.
        /// </summary>
        /// <value>
        /// The directors.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public List<string> Directors { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the actors.
        /// </summary>
        /// <value>
        /// The actors.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public List<string> Actors { get; set; } = new List<string>();

    }
}
