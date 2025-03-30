using System;
using System.Collections.Generic;

namespace Backend_MiSalud.Models;

public partial class Diagnosis
{
    public int IdDiagnostico { get; set; }

    public int? IdHistorial { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaDiagnostico { get; set; }

    public virtual MedicalHistory? IdHistorialNavigation { get; set; }
}
