using System;
using System.Collections.Generic;

namespace Backend_MiSalud.Models;

public partial class Administrator
{
    public int IdAdministrador { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }
}
