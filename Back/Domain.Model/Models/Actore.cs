﻿namespace WebSeries.Models;

public partial class Actore
{
    public long ActorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public long PaisId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Paise Pais { get; set; } = null!;

    public virtual ICollection<PeliculasActore> PeliculasActores { get; set; } = new List<PeliculasActore>();

}
