using Backend_MiSalud.Models;

namespace Backend_MiSalud.Clases
{
    public class ClsAppointment 
    {
        private readonly MiSaludContext dbMiSalud = new MiSaludContext();
        public List<MedicalAppointment> GetAppointments()
        {
            return dbMiSalud.MedicalAppointments.ToList();
        }
        public MedicalAppointment GetAppointmentById(int id)
        {
            return dbMiSalud.MedicalAppointments.FirstOrDefault(ma => ma.IdCita == id);
        }

        public List<MedicalAppointment> GetAppointmentsByPatientId(int patientId)
        {
            return dbMiSalud.MedicalAppointments.Where(ma => ma.IdPaciente == patientId).ToList();
        }

        public List<MedicalAppointment> GetAppointmentsByCedula(string cedula)
        {
            Patient patient = dbMiSalud.Patients.FirstOrDefault(p => p.Cedula == cedula);
            if (patient == null) {
                return [];
            }
            return GetAppointmentsByPatientId(patient.IdPaciente);
        }

        public List<MedicalAppointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return dbMiSalud.MedicalAppointments.Where(ma => ma.IdDoctor == doctorId).ToList();
        }

        public string AddAppointment(MedicalAppointment appointment)
        {
            try{
                dbMiSalud.MedicalAppointments.Add(appointment);
                dbMiSalud.SaveChanges();
                return "Cita médica registrada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al registrar la cita medica: " + ex.Message;
            }
            
        }

        public string UpdateAppointment(MedicalAppointment appointment)
        {
            if (appointment == null)
            {
                return "Estructura invalida o null";
            }

            try
            {
                MedicalAppointment updateAppointment = dbMiSalud.MedicalAppointments.Find(appointment.IdCita);
                if (updateAppointment == null)
                {
                    return "Error404: Cita médica no encontrada.";
                }

                updateAppointment.IdDoctor = appointment.IdDoctor;
                updateAppointment.Title = appointment.Title;
                updateAppointment.DescriptionAppointment = appointment.DescriptionAppointment;
                updateAppointment.PlaceAppointment = appointment.PlaceAppointment;
                updateAppointment.FechaCita = appointment.FechaCita;
                updateAppointment.HoraCita = appointment.HoraCita;
                updateAppointment.HoraFinalizacion = appointment.HoraFinalizacion;
                updateAppointment.Estado = appointment.Estado;
                updateAppointment.IdDoctorNavigation = dbMiSalud.Doctors.Find(appointment.IdDoctor);

                dbMiSalud.MedicalAppointments.Update(updateAppointment);
                dbMiSalud.SaveChanges();
                return "Cita médica actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar la cita médica: " + ex.Message;

            }
        }
        public string DeleteAppointment(int id)
        {
            try
            {
                MedicalAppointment appointment = dbMiSalud.MedicalAppointments.Find(id);

                if (appointment == null)
                {
                    return "Error404: Cita médica no encontrada.";
                }

                dbMiSalud.MedicalAppointments.Remove(appointment);
                dbMiSalud.SaveChanges();
                return "Cita médica eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar la cita médica: " + ex.Message;

            }
        }
    }
}
