using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend_MiSalud.Models;

public partial class MedicalAppointment
{
    public int IdCita { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdDoctor { get; set; }

    public string? Title { get; set; }

    public string? DescriptionAppointment { get; set; }

    public string? PlaceAppointment { get; set; }

    public DateOnly? FechaCita { get; set; }

    public TimeOnly? HoraCita { get; set; }

    public TimeOnly? HoraFinalizacion { get; set; }

    public string? Estado { get; set; }
    [JsonIgnore]

    public virtual Doctor? IdDoctorNavigation { get; set; }
    [JsonIgnore]

    public virtual Patient? IdPacienteNavigation { get; set; }
}
