﻿namespace WebSeries.Models;

public partial class Paise
{
    public long PaisId { get; set; }

    public string Nombre { get; set; } = null!;
    public bool IsDeleted { get; set; }

    public virtual ICollection<Actore> Actores { get; set; } = new List<Actore>();

    public virtual ICollection<Directore> Directores { get; set; } = new List<Directore>();

    public virtual ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
}
