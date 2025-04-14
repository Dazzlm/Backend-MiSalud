using Backend_MiSalud.Clases;
using Backend_MiSalud.Models;
using Microsoft.AspNetCore.Mvc;
using static Backend_MiSalud.Models.LibAppointmentDetails;

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
                return NotFound(new
                {
                    success = false,
                    message = "No se encontraron citas médicas."
                });
            }

            return Ok(new
            {
                success = true,
                data = appointments
            });
        }

        [HttpGet]
        [Route("GetMedicalAppointmentById/{id}")]
        public IActionResult GetMedicalAppointmentById(int id)
        {

            ClsAppointment clsAppointment = new ClsAppointment();
            MedicalAppointment appointment = clsAppointment.GetAppointmentById(id);

            if (appointment == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Cita médica no encontrada."
                });
            }

            return Ok(new
            {
                success = true,
                data = appointment
            });

            
        }

        [HttpGet]
        [Route("GetMedicalAppointmentsByPatientId/{patientId}")]
        public IActionResult GetMedicalAppointmentsByPatientId(int patientId)
        {
            ClsAppointment clsAppointment = new ClsAppointment();
            List<MedicalAppointment> appointments = clsAppointment.GetAppointmentsByPatientId(patientId);
            if (appointments == null || appointments.Count == 0)
            {
                return NotFound(new
                {
                    success = false,
                    message = "No se encontraron citas médicas para el paciente con id: "+patientId
                });
            }

            return Ok(new
            {
                success = true,
                data = appointments
            });
        }

        [HttpGet]
        [Route("GetMedicalAppointmentsByCedula/{cedula}")]
        public IActionResult GetMedicalAppointmentsByCedula(string cedula)
        {
            ClsAppointment clsAppointment = new ClsAppointment();
            List<MedicalAppointment> appointments = clsAppointment.GetAppointmentsByCedula(cedula);
            if (appointments == null || appointments.Count == 0)
            {
                return NotFound(new
                {
                    success = false,
                    message = "No se encontraron citas médicas para el paciente con cedula: " + cedula
                });
            }

            return Ok(new
            {
                success = true,
                data = appointments
            });
        }

        [HttpGet]
        [Route("GetMedicalAppointmentsByDoctorId/{doctorId}")]
        public IActionResult GetMedicalAppointmentsByDoctorId(int doctorId)
        {
            ClsAppointment clsAppointment = new ClsAppointment();
            List<MedicalAppointment> appointments = clsAppointment.GetAppointmentsByDoctorId(doctorId);
            if (appointments == null || appointments.Count == 0)
            {
                return NotFound(new
                {
                    success = false,
                    message = "No se encontraron citas médicas para el doctor con ID: " + doctorId
                });
            }

            return Ok(new
            {
                success = true,
                data = appointments
            });
        }
        [HttpPost]
        [Route("AddMedicalAppointment")]
        public IActionResult AddMedicalAppointment([FromBody] MedicalAppointment appointment)
        {
            ClsAppointment clsAppointment = new ClsAppointment();

            if (appointment == null)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Estructura inválida o nula"
                });
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
                return BadRequest(new
                {
                    success = false,
                    message = "Estructura inválida o nula"
                });
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

        [HttpGet]
        [Route("GetMedicalAppointmentsDetails/{id}")]
        public IActionResult GetMedicalAppointmentsDetails(int id)
        {
            ClsAppointment clsAppointment = new ClsAppointment();
            CitaDetalleDto appointmentDetails = clsAppointment.GetAppointmentDetails(id);

            if (appointmentDetails == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "No se encontraron detalles de la cita médica con ID: " + id
                });
            }

            return Ok(new
            {
                success = true,
                data = appointmentDetails
            });
        }

        [NonAction]
        private IActionResult ValidationResult(string result)
        {
            if (result.Contains("Error404"))
            {
                return NotFound(new
                {
                    success = false,
                    message = result
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
                message = result
            });
        }

    }
}
