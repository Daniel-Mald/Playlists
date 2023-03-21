using System;
using System.Collections.Generic;

namespace ProyectoListasdeReproduccion.Models;

public partial class Canciones
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Artista { get; set; } = null!;

    public string? Duracion { get; set; }

    public string Genero { get; set; } = null!;

    public int ListaId { get; set; }

    public virtual Listas Lista { get; set; } = null!;
}
