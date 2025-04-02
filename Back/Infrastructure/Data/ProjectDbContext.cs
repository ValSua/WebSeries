using Microsoft.EntityFrameworkCore;
using WebSeries.Models;

namespace WebSeries.Data;

public partial class ProjectDbContext : DbContext
{
    public ProjectDbContext()
    {
    }

    public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actore> Actores { get; set; }

    public virtual DbSet<Directore> Directores { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<PeliculasActore> Peliculas_Actores { get; set; }

    public virtual DbSet<PeliculasDirectore> PeliculasDirectores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actore>(entity =>
        {
            entity.HasKey(e => e.ActorId).HasName("PK__Actores__57B3EA4B267B5DDF");

            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.Pais).WithMany(p => p.Actores)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Actores_Paises");
        });

        modelBuilder.Entity<Directore>(entity =>
        {
            entity.HasKey(e => e.DirectorId);

            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.Pais).WithMany(p => p.Directores)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Directores_Paises");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.GeneroId).HasName("PK__Generos__A99D02483D81C7E4");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.PaisId).HasName("PK__Paises__B501E1854EC02E8C");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.PeliculaId).HasName("PK__Pelicula__5AC6FCCCEB1F7E12");

            entity.Property(e => e.CodigoTrailer).HasMaxLength(500);
            entity.Property(e => e.ImagenPortada).HasMaxLength(500);
            entity.Property(e => e.Titulo).HasMaxLength(255);

            entity.HasOne(d => d.Genero).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.GeneroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Peliculas_Generos");

            entity.HasOne(d => d.Pais).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Peliculas_Paises");
        });

        modelBuilder.Entity<PeliculasActore>(entity =>
        {
            entity.HasKey(e => new { e.PeliculaId, e.ActorId }).HasName("PK__Pelicula__FFBDC2687A272305");

            entity.ToTable("Peliculas_Actores");

            entity.HasOne(d => d.Actor).WithMany(p => p.PeliculasActores)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Peliculas__Actor__59063A47");

            entity.HasOne(d => d.Pelicula).WithMany(p => p.PeliculasActores)
                .HasForeignKey(d => d.PeliculaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Peliculas__Pelic__5812160E");
        });

        modelBuilder.Entity<PeliculasDirectore>(entity =>
        {
            entity.HasKey(e => new { e.PeliculaId, e.DirectorId }).HasName("PK__Pelicula__28AA95283CE263F9");

            entity.ToTable("Peliculas_Directores");

            entity.HasOne(d => d.Director).WithMany(p => p.PeliculasDirectores)
                .HasForeignKey(d => d.DirectorId)
                .HasConstraintName("FK__Peliculas__Direc__6E01572D");

            entity.HasOne(d => d.Pelicula).WithMany(p => p.PeliculasDirectores)
                .HasForeignKey(d => d.PeliculaId)
                .HasConstraintName("FK__Peliculas__Pelic__6D0D32F4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
