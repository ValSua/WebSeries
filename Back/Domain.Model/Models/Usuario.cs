namespace WebSeries.Models;

public partial class Usuario
{
    public long UsuarioId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
