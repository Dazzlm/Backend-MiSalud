using System;
using System.Collections.Generic;

namespace Backend_MiSalud.Models;

public partial class Recommendation
{
    public int IdRecomendacion { get; set; }

    public int? IdHistorial { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaRecomendacion { get; set; }

    public virtual MedicalHistory? IdHistorialNavigation { get; set; }
}
