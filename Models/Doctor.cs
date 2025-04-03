using System;
using System.Collections.Generic;

namespace Backend_MiSalud.Models;

public partial class Doctor
{
    public int IdDoctor { get; set; }

    public int? Rethus { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Especialidad { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? PasswordDoctor { get; set; }

    public virtual ICollection<MedicalAppointment> MedicalAppointments { get; set; } = new List<MedicalAppointment>();
}
