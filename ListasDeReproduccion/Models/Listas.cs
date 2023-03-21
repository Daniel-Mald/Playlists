using System;
using System.Collections.Generic;

namespace ProyectoListasdeReproduccion.Models;

public partial class Listas
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Creador { get; set; }

    public virtual ICollection<Canciones> Canciones { get; } = new List<Canciones>(); //me da las canciones 
}
