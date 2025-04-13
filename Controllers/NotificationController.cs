using Backend_MiSalud.Clases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MiSalud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        [HttpPost]
        [Route("SendEmailToPatients")]
        public IActionResult SendEmailToPatients(string body,string subject)
        {
            ClsNotificaciones clsNotificaciones = new ClsNotificaciones();
            string result = clsNotificaciones.CreateNotificationPatients(subject, body);
            return ValidationResult(result);
        }

        [HttpPost]
        [Route("SendEmailToDoctors")]
        public IActionResult SendEmailToDoctors(string body, string subject)
        {
            ClsNotificaciones clsNotificaciones = new ClsNotificaciones();
            string result = clsNotificaciones.CreateNotificationDoctors(subject, body);
            return ValidationResult(result);
        }

        [HttpPost]
        [Route("SendEmailToAdmis")]
        public IActionResult SendEmailToAdmins(string body, string subject)
        {
            ClsNotificaciones clsNotificaciones = new ClsNotificaciones();
            string result = clsNotificaciones.CreateNotificationAdmins (subject, body);
            return ValidationResult(result);
        }

        [HttpPost]
        [Route("SendEmailToAll")]
        public IActionResult SendEmailToAll(string body, string subject)
        {
            ClsNotificaciones clsNotificaciones = new ClsNotificaciones();
            string result = clsNotificaciones.CreateNotificationAll(subject, body);
            return ValidationResult(result);
        }

        [NonAction]
        private IActionResult ValidationResult(string result)
        {
            if (result.Contains("Error404"))
            {
                return NotFound(new
                {
                    success = false,
                    message = "No se encontraron correos para los pacientes."
                });
            }

            if (result.Contains("Error"))
            {
                return BadRequest(new
                {
                    success = false,
                    message = result
                });
            }

            return Ok(new
            {
                success = true,
                data = result
            });
        }
    }
}
