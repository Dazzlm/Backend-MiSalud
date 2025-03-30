using System;
using System.Collections.Generic;

namespace Backend_MiSalud.Models;

public partial class MedicalAppointment
{
    public int IdCita { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdDoctor { get; set; }

    public DateOnly? FechaCita { get; set; }

    public TimeOnly? HoraCita { get; set; }

    public TimeOnly? HoraFinalizacion { get; set; }

    public string? Estado { get; set; }

    public virtual Doctor? IdDoctorNavigation { get; set; }

    public virtual Patient? IdPacienteNavigation { get; set; }
}
