﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend_MiSalud.Models;

public partial class MedicalExamination
{
    public int IdExamen { get; set; }

    public int? IdHistorial { get; set; }

    public string? TipoExamen { get; set; }

    public string? Resultado { get; set; }

    public DateOnly? FechaExamen { get; set; }
    [JsonIgnore]

    public virtual MedicalHistory? IdHistorialNavigation { get; set; }
}
