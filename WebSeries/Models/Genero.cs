using System;
using System.Collections.Generic;

namespace WebSeries.Models;

public partial class Genero
{
    public long GeneroId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
}
