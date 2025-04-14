namespace Backend_MiSalud.Models
{
    public class LibAppointmentDetails
    {
        public class CitaDetalleDto
        {
            public DateOnly? Fecha { get; set; }
            public TimeOnly? HoraInicio { get; set; }
            public TimeOnly? HoraFin { get; set; }
            public PacienteDto? Paciente { get; set; }
            public DoctorDto? Doctor { get; set; }
            public string? Titulo { get; set; }
            public string? Descripcion { get; set; }
            public string? Lugar { get; set; }
        }

        public class PacienteDto
        {
            public string? NombreCompleto { get; set; }
            public string? Cedula { get; set; }
            public string? Correo { get; set; }
            public string? Telefono { get; set; }
        }

        public class DoctorDto
        {
            public string? NombreCompleto { get; set; }
            public string? Correo { get; set; }
            public string? Telefono { get; set; }
        }

    }
}
