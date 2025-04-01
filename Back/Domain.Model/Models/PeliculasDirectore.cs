using System;
using System.Collections.Generic;

namespace WebSeries.Models;

public partial class PeliculasDirectore
{
    public long PeliculaId { get; set; }

    public long DirectorId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Directore Director { get; set; } = null!;

    public virtual Pelicula Pelicula { get; set; } = null!;
}
