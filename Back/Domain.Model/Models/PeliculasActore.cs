using System;
using System.Collections.Generic;

namespace WebSeries.Models;

public partial class PeliculasActore
{
    public long PeliculaId { get; set; }

    public long ActorId { get; set; }

    public bool IsDeleted { get; set; }

}
