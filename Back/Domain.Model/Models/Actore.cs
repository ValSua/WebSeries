using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSeries.Models;

public partial class Actore
{
    public long ActorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public long PaisId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string PaisNombre { get; set; } = null!;

    public Paise Pais { get; set; } = null!;

    public List<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
}
