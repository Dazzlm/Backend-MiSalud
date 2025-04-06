using Backend_MiSalud.Clases.Notification;
using Backend_MiSalud.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Net;
using System.Net.Mail;


namespace Backend_MiSalud.Clases
{
    public class ClsNotificaciones
    {
        private readonly MiSaludContext _dbMiSalud = new MiSaludContext();
        private readonly IConfiguration _emailSettings;
        private readonly string _from;
        private readonly SmtpClient _smtpServer;
        public ClsNotificaciones()
        {
            _emailSettings = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();
            _from = _emailSettings["Mail:From"]!;
            string password = _emailSettings["Mail:Password"]!;
            string smtp = _emailSettings["Mail:Smtp"]!;
            int port = int.Parse(_emailSettings["Mail:Port"]!);

             _smtpServer = new SmtpClient
            {
                Host = smtp,
                Port = port,
                Credentials = new NetworkCredential(_from, password),
                EnableSsl = true
            };
        }

        public string CreateNotification(string toEmail,string subject,string body) {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_from);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body =body;
                _smtpServer.Send(mail);
                return "Correo enviado exitosamente.";
            }
            catch (Exception ex)
            {
                return "Error al enviar el correo: " + ex.Message;
            }
        }

        private string SendNotification(List<string> emails, string subject, string body, string grupo)
        {
            try
            {
                if (emails == null || emails.Count == 0)
                    return $"Error404: No se encontraron correos para {grupo}.";

                GlobalNotifier notifier = new GlobalNotifier(subject, body);
                SubscribeEmails(notifier, emails);
                notifier.NotifyAll();

                return $"Correos enviados a los {grupo}.";
            }
            catch (Exception ex)
            {
                return $"Error al enviar correos a los {grupo}: {ex.Message}";
            }
        }

        public string CreateNotificationPatients(string subject, string body)
        {
            List<Patient> patients = _dbMiSalud.Patients.ToList();
            List<string> emails =patients.Select(p => p.Correo).ToList();

            return SendNotification(emails, subject, body, "Pacientes");
        }

        public string CreateNotificationDoctors(string subject, string body)
        {
            List<Doctor> doctors = _dbMiSalud.Doctors.ToList();
            List<string> emails = doctors.Select(d => d.Correo).ToList();

            return SendNotification(emails, subject, body, "Doctores");
        }

        public string CreateNotificationAdmins(string subject, string body)
        {
            List<Administrator> administrators = _dbMiSalud.Administrators.ToList();
            List<string> emails = administrators.Select(d => d.Correo).ToList();
            
            return SendNotification(emails, subject, body, "Admins");
        }

        public string CreateNotificationAll(string subject, string body)
        {
            List<Patient> patients = _dbMiSalud.Patients.ToList();
            List<Doctor> doctors = _dbMiSalud.Doctors.ToList();
            List<Administrator> administrators = _dbMiSalud.Administrators.ToList();
            List<string> emails = patients.Select(p => p.Correo).ToList();
            emails.AddRange(doctors.Select(d => d.Correo));
            emails.AddRange(administrators.Select(a => a.Correo));

            return SendNotification(emails, subject, body, "Usuarios");
        }

        public string GenerateNotifyAppointment(MedicalAppointment appointment, string type)
        {
            string subject = type switch
            {
                "NewAppointment" => "Cita médica Programada",
                "RescheduleAppointment" => "Cita médica Reprogramada",
                _ => ""
            };

            if (subject == "")
                return "Error404: Tipo de notificación no válido.";

            MiSaludContext _dbMiSalud = new MiSaludContext();
            Doctor doctor = _dbMiSalud.Doctors.FirstOrDefault(d => d.IdDoctor == appointment.IdDoctor);
            Patient patient = _dbMiSalud.Patients.FirstOrDefault(p => p.IdPaciente == appointment.IdPaciente);

            string toEmailPatient = patient.Correo;
            string toEmailDoctor = doctor.Correo;

            string appointmentDescription = $"📅 *{subject}*\n" +
                                                 $"──────────────────────────────────\n" +
                                                 $"🗓 Fecha: {appointment.FechaCita:dd/MM/yyyy}\n" +
                                                 $"⏰ Hora: {appointment.HoraCita} - {appointment.HoraFinalizacion}\n\n" +

                                                 $"👤 *Paciente:*\n" +
                                                 $"   - Nombre: {patient.NombreCompleto}\n" +
                                                 $"   - Cédula: {patient.Cedula}\n" +
                                                 $"   - Correo: {patient.Correo}\n" +
                                                 $"   - Telefono: {patient.Telefono}\n\n" +

                                                 $"👨🏽‍⚕️ *Doctor:*\n" +
                                                 $"   - Nombre: {doctor.NombreCompleto}\n" +
                                                 $"   - Correo: {doctor.Correo}\n" +
                                                 $"   - Telefono:  {doctor.Telefono}\n\n" +

                                                 $"📌 *Título de la cita:*\n" +
                                                 $"   {appointment.Title}\n\n" +

                                                 $"📝 *Descripción:*\n" +
                                                 $"   {appointment.DescriptionAppointment}\n\n" +

                                                 $"📍 *Lugar de la cita:*\n" +
                                                 $"   {appointment.PlaceAppointment}\n\n" +

                                                 $"❗ *Indicaciones importantes:*\n" +
                                                 $"- Preséntese entre 10 a 20 minutos antes de la hora programada.\n" +
                                                 $"- Para reprogramar su cita, hágalo con al menos 24 horas de anticipación.\n" +
                                                 $"- Si no puede asistir, por favor cancele su cita para ceder el espacio a otro paciente.\n";

            
            try
            {
                CreateNotification(toEmailPatient, subject, appointmentDescription);
                CreateNotification(toEmailDoctor, subject, appointmentDescription);

                return "Correos enviados a los pacientes y doctores exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al enviar notificaciones de la cita: {ex.Message}";
            }

        }

        private void SubscribeEmails(GlobalNotifier notifier, List<string> emails)
        {
            foreach (string email in emails)
            {
                notifier.AddObserver(new EmailObserver(email, this));
            }
        }
    }
}
