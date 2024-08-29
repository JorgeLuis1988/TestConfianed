using System;
using System.Collections.Generic;

namespace ApiConfiamed.Models;

public partial class Usuario
{
    public int IdUser { get; set; }

    public string? Identificacion { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public decimal? Estatura { get; set; }

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();
}
