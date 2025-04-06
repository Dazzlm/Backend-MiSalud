using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend_MiSalud.Models;

public partial class Patient
{
    public int IdPaciente { get; set; }

    public string? NombreCompleto { get; set; }
    public string? Cedula { get; set; }
    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? PasswordPatient { get; set; }
    [JsonIgnore]

    public virtual ICollection<MedicalAppointment> MedicalAppointments { get; set; } = new List<MedicalAppointment>();
    [JsonIgnore]

    public virtual MedicalHistory? MedicalHistory { get; set; }
}
