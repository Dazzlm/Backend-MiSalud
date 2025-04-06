using Backend_MiSalud.Clases;
using Backend_MiSalud.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MiSalud.Controllers
{
    [ApiController]
    [Route("api/MedicalAppointment")]
    
    public class AppointmentController : ControllerBase
    {
        [HttpGet]
        [Route("GetMedicalAppointments")]
        public IActionResult GetMedicalAppointments()
        {
            ClsAppointment clsAppointment = new ClsAppointment();
            List<MedicalAppointment> appointments = clsAppointment.GetAppointments();
            if (appointments == null || appointments.Count == 0)
            {
                return NotFound("No se encontraron citas médicas.");
            }
            return Ok(appointments);
        }

        [HttpGet]
        [Route("GetMedicalAppointmentById/{id}")]
        public IActionResult GetMedicalAppointmentById(int id)
        {

            ClsAppointment clsAppointment = new ClsAppointment();
            MedicalAppointment appointment = clsAppointment.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound("Cita médica no encontrada.");
            }
            return Ok(appointment);
        }

        [HttpGet]
        [Route("GetMedicalAppointmentsByPatientId/{patientId}")]
        public IActionResult GetMedicalAppointmentsByPatientId(int patientId)
        {
            ClsAppointment clsAppointment = new ClsAppointment();
            List<MedicalAppointment> appointments = clsAppointment.GetAppointmentsByPatientId(patientId);
            if (appointments == null || appointments.Count == 0)
            {
                return NotFound("No se encontraron citas médicas para el paciente.");
            }
            return Ok(appointments);
        }

        [HttpGet]
        [Route("GetMedicalAppointmentsByCedula/{cedula}")]
        public IActionResult GetMedicalAppointmentsByCedula(string cedula)
        {
            ClsAppointment clsAppointment = new ClsAppointment();
            List<MedicalAppointment> appointments = clsAppointment.GetAppointmentsByCedula(cedula);
            if (appointments == null || appointments.Count == 0)
            {
                return NotFound("No se encontraron citas médicas para el paciente con cédula: " + cedula);
            }
            return Ok(appointments);
        }

        [HttpGet]
        [Route("GetMedicalAppointmentsByDoctorId/{doctorId}")]
        public IActionResult GetMedicalAppointmentsByDoctorId(int doctorId)
        {
            ClsAppointment clsAppointment = new ClsAppointment();
            List<MedicalAppointment> appointments = clsAppointment.GetAppointmentsByDoctorId(doctorId);
            if (appointments == null || appointments.Count == 0)
            {
                return NotFound("No se encontraron citas médicas para el doctor con ID: " + doctorId);
            }
            return Ok(appointments);
        }
        [HttpPost]
        [Route("AddMedicalAppointment")]
        public IActionResult AddMedicalAppointment([FromBody] MedicalAppointment appointment)
        {
            ClsAppointment clsAppointment = new ClsAppointment();

            if (appointment == null)
            {
                return BadRequest("Estructura inválida o nula");
            }
            string result = clsAppointment.AddAppointment(appointment);
            return ValidationResult(result);;
        }
        [HttpPut]
        [Route("UpdateMedicalAppointment")]
        public IActionResult UpdateMedicalAppointment([FromBody] MedicalAppointment appointment)
        {
            ClsAppointment clsAppointment = new ClsAppointment();
            if (appointment == null)
            {
                return BadRequest("Estructura inválida o nula");
            }
            string result = clsAppointment.UpdateAppointment(appointment);

            return ValidationResult(result);
        }
        [HttpDelete]
        [Route("DeleteMedicalAppointment/{id}")]
        public IActionResult DeleteMedicalAppointment(int id)
        {
            ClsAppointment clsAppointment = new ClsAppointment();
            string result = clsAppointment.DeleteAppointment(id);
            return ValidationResult(result);
           
        }

        [NonAction]
        private IActionResult ValidationResult(string result) {
            if (result.Contains("Error404"))
            {
                return NotFound(result);
            }

            if (result.Contains("Error"))
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

    }
}
