namespace WebSeries.Models;

public partial class Pelicula
{
    public long PeliculaId { get; set; }

    public long GeneroId { get; set; }

    public long PaisId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Reseña { get; set; }

    public string? ImagenPortada { get; set; }

    public string? CodigoTrailer { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Genero Genero { get; set; } = null!;

    public virtual Paise Pais { get; set; } = null!;

    public virtual ICollection<PeliculasActore> PeliculasActores { get; set; } = new List<PeliculasActore>();

    public virtual ICollection<PeliculasDirectore> PeliculasDirectores { get; set; } = new List<PeliculasDirectore>();
}
