using Backend_MiSalud.Models;

namespace Backend_MiSalud.Clases
{
    public class ClsPatient
    {
        private readonly MiSaludContext dbMiSalud = new MiSaludContext();

        public Patient GetAppointmentsByPatientId(int patientId)
        {
            return dbMiSalud.Patients.FirstOrDefault(p => p.IdPaciente == patientId);
        }

        public Patient GetAppointmentsByCedula(string cedula)
        {
            return dbMiSalud.Patients.FirstOrDefault(p => p.Cedula == cedula);
        }

        public Patient GetAppointmentsByCorreo(string correo)
        {
            return dbMiSalud.Patients.FirstOrDefault(p => p.Correo == correo);
        }

        public bool ExistsByCedula(string cedula)
        {
            return dbMiSalud.Patients.Any(p => p.Cedula == cedula);
        }

        public bool ExistsByCorreo(string correo)
        {
            return dbMiSalud.Patients.Any(p => p.Correo == correo);
        }

        public string AddPatient(Patient patient)
        {
            try
            {
                if (ExistsByCedula(patient.Cedula))
                {
                    return "Error: ya existe un paciente con esa cédula.";
                }

                if (ExistsByCorreo(patient.Correo))
                {
                    return "Error: ya existe un paciente con ese correo.";
                }

                dbMiSalud.Patients.Add(patient);
                dbMiSalud.SaveChanges();
                return "Paciente registrado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al registrar el paciente: " + ex.Message;
            }
        }

        public string DeleteAppointment(int id)
        {
            try
            {
                Patient patient = dbMiSalud.Patients.Find(id);

                if (patient == null)
                {
                    return "Error404: paciente no encontrado.";
                }

                dbMiSalud.Patients.Remove(patient);
                dbMiSalud.SaveChanges();
                return "Paciente eliminado con exito.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el Paciente: " + ex.Message;
            }
        }
    }
}
