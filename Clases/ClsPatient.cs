using Backend_MiSalud.Models;

namespace Backend_MiSalud.Clases
{
    public class ClsPatient
    {
        private readonly MiSaludContext dbMiSalud = new MiSaludContext() ;
        public Patient GetAppointmentsByPatientId(int patientId)
        {
            return dbMiSalud.Patients.FirstOrDefault(p => p.IdPaciente == patientId);
        }

        public Patient GetAppointmentsByCedula(string cedula)
        {
            return dbMiSalud.Patients.FirstOrDefault(p => p.Cedula == cedula);
        }

        public string AddPatient(Patient patient)
        {
            try
            {
                dbMiSalud.Patients.Add(patient);
                dbMiSalud.SaveChanges();
                return "Paciente registrado correctamente.";
            }
            catch (Exception ex)
            {
                
                string errorMessage = ex.InnerException?.Message?.ToLower() ?? ex.Message.ToLower();
                if (errorMessage.Contains("unique") || errorMessage.Contains("violación") || errorMessage.Contains("duplicate"))
                {
                    if (errorMessage.Contains("IX_Patient_Cedula".ToLower()))
                        return "Error: ya existe un paciente con esa cédula.";

                    if (errorMessage.Contains("UQ__Patient__2A586E0B8556AC7E".ToLower()))
                        return "Error: ya existe un paciente con ese correo.";

                    return "Error: uno de los campos únicos ya está registrado. "+ errorMessage;
                }

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
