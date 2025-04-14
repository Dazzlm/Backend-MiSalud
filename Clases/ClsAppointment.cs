using Backend_MiSalud.Clases.Notification;
using Backend_MiSalud.Models;
using System.Numerics;
using static Backend_MiSalud.Models.LibAppointmentDetails;

namespace Backend_MiSalud.Clases
{
    public class ClsAppointment 
    {
        private readonly MiSaludContext _dbMiSalud = new MiSaludContext();
        private readonly ClsNotificaciones _clsNotificaciones = new ClsNotificaciones();
        public List<MedicalAppointment> GetAppointments()
        {
            return _dbMiSalud.MedicalAppointments.ToList();
        }
        public MedicalAppointment GetAppointmentById(int id)
        {
            return _dbMiSalud.MedicalAppointments.FirstOrDefault(ma => ma.IdCita == id);
        }

        public List<MedicalAppointment> GetAppointmentsByPatientId(int patientId)
        {
            return _dbMiSalud.MedicalAppointments.Where(ma => ma.IdPaciente == patientId).ToList();
        }

        public List<MedicalAppointment> GetAppointmentsByCedula(string cedula)
        {
            Patient patient = _dbMiSalud.Patients.FirstOrDefault(p => p.Cedula == cedula);
            if (patient == null) {
                return [];
            }
            return GetAppointmentsByPatientId(patient.IdPaciente);
        }

        public List<MedicalAppointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return _dbMiSalud.MedicalAppointments.Where(ma => ma.IdDoctor == doctorId).ToList();
        }

        public string AddAppointment(MedicalAppointment appointment)
        {
            try{
                _dbMiSalud.MedicalAppointments.Add(appointment);
                _dbMiSalud.SaveChanges();
                string result = _clsNotificaciones.GenerateNotifyAppointment(appointment, "NewAppointment");
                return "Cita médica registrada correctamente y "+result;
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
                MedicalAppointment updateAppointment = _dbMiSalud.MedicalAppointments.Find(appointment.IdCita);
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
                updateAppointment.IdDoctorNavigation = _dbMiSalud.Doctors.Find(appointment.IdDoctor);

                _dbMiSalud.MedicalAppointments.Update(updateAppointment);
                _dbMiSalud.SaveChanges();
                string result = _clsNotificaciones.GenerateNotifyAppointment(appointment, "RescheduleAppointment");
                return "Cita médica actualizada correctamente y " + result;
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
                MedicalAppointment appointment = _dbMiSalud.MedicalAppointments.Find(id);

                if (appointment == null)
                {
                    return "Error404: Cita médica no encontrada.";
                }

                _dbMiSalud.MedicalAppointments.Remove(appointment);
                _dbMiSalud.SaveChanges();
                return "Cita médica eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar la cita médica: " + ex.Message;
            }
        }

        public CitaDetalleDto GetAppointmentDetails (int id){
            
            MedicalAppointment appointment = _dbMiSalud.MedicalAppointments.Find(id);

            if (appointment == null)
            {
                return null;
            }
            Doctor doctor = _dbMiSalud.Doctors.FirstOrDefault(d => d.IdDoctor == appointment.IdDoctor);
            Patient patient = _dbMiSalud.Patients.FirstOrDefault(p => p.IdPaciente == appointment.IdPaciente);

            string toEmailPatient = patient.Correo;
            string toEmailDoctor = doctor.Correo;

            CitaDetalleDto citaDetalle = new CitaDetalleDto
            {
                Fecha = appointment.FechaCita,
                HoraInicio = appointment.HoraCita,
                HoraFin = appointment.HoraFinalizacion,
                Paciente = new PacienteDto
                {
                    NombreCompleto = patient.NombreCompleto,
                    Cedula = patient.Cedula,
                    Correo = patient.Correo,
                    Telefono = patient.Telefono
                },
                Doctor = new DoctorDto
                {
                    NombreCompleto = doctor.NombreCompleto,
                    Correo = doctor.Correo,
                    Telefono = doctor.Telefono
                },
                Titulo = appointment.Title,
                Descripcion = appointment.DescriptionAppointment,
                Lugar = appointment.PlaceAppointment
            };

            return citaDetalle;

        }
    }
}
