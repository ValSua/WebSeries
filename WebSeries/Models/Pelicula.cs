using System;
using System.Collections.Generic;

namespace WebSeries.Models;

public partial class Pelicula
{
    public long PeliculaId { get; set; }

    public long GeneroId { get; set; }

    public long PaisId { get; set; }

    public long DirectorId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Reseña { get; set; }

    public string? ImagenPortada { get; set; }

    public string? CodigoTrailer { get; set; }

    public virtual Directore Director { get; set; } = null!;

    public virtual Genero Genero { get; set; } = null!;

    public virtual Paise Pais { get; set; } = null!;

    public virtual ICollection<Actore> Actors { get; set; } = new List<Actore>();
}
