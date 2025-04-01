namespace WebSeries.Models;

public partial class PeliculasActore
{
    public long PeliculaId { get; set; }

    public long ActorId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Actore Actor { get; set; } = null!;

    public virtual Pelicula Pelicula { get; set; } = null!;
}
