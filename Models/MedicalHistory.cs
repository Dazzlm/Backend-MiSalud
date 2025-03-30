using System;
using System.Collections.Generic;

namespace Backend_MiSalud.Models;

public partial class MedicalHistory
{
    public int IdHistorial { get; set; }

    public int? IdPaciente { get; set; }

    public string? NombrePaciente { get; set; }

    public int? Edad { get; set; }

    public string? Genero { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? EstadoCivil { get; set; }

    public string? Ocupacion { get; set; }

    public string? Aseguradora { get; set; }

    public string? TipoSangre { get; set; }

    public string? ContactoEmergencia { get; set; }

    public string? AntecedentesPersonales { get; set; }

    public string? AntecedentesFamiliares { get; set; }

    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();

    public virtual Patient? IdPacienteNavigation { get; set; }

    public virtual ICollection<MedicalExamination> MedicalExaminations { get; set; } = new List<MedicalExamination>();

    public virtual ICollection<Recommendation> Recommendations { get; set; } = new List<Recommendation>();
}
