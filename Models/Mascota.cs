using System;
using System.Collections.Generic;

namespace ApiConfiamed.Models;

public partial class Mascota
{
    public int IdMascota { get; set; }

    public string? Nombre { get; set; }

    public string? Especie { get; set; }

    public string? Raza { get; set; }

    public string? Color { get; set; }

    public int? IdUser { get; set; }

    public virtual Usuario? IdUserNavigation { get; set; }
}
