using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend_MiSalud.Models;

public partial class Diagnosis
{
    public int IdDiagnostico { get; set; }

    public int? IdHistorial { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaDiagnostico { get; set; }
    [JsonIgnore]
    public virtual MedicalHistory? IdHistorialNavigation { get; set; }
}
