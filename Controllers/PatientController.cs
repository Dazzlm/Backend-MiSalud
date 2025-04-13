using Backend_MiSalud.Clases;
using Backend_MiSalud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MiSalud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        
        [HttpGet]
        [Route("GetPatientById/{patientId}")]
        public IActionResult GetPatientById(int patientId)
        {
            ClsPatient clsPatient = new ClsPatient();
            Patient patient = clsPatient.GetAppointmentsByPatientId(patientId);
            if (patient == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Paciente no encontrado"
                });
            }
            return Ok(new
            {
                success = true,
                data = patient
            });
        }
        [HttpGet]
        [Route("GetPatientByCedula/{cedula}")]
        public IActionResult GetPatientByCedula(string cedula)
        {
            ClsPatient clsPatient = new ClsPatient();
            Patient patient = clsPatient.GetAppointmentsByCedula(cedula);
            if (patient == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Paciente no encontrado"
                });
            }
            return Ok(new
            {
                success = true,
                data = patient
            });
        }

        [HttpPost]
        [Route("AddPatient")]
        public IActionResult AddPatient([FromBody] Patient patient)
        {
            ClsPatient clsPatient = new ClsPatient();
            string result = clsPatient.AddPatient(patient);
            return ValidationResult(result);
        }

        [HttpDelete]
        [Route("DeletePatient/{id}")]
        public IActionResult DeletePatient(int id)
        {
            ClsPatient clsPatient = new ClsPatient();
            string result = clsPatient.DeleteAppointment(id);
            return ValidationResult(result);
        }
        [NonAction]
        private IActionResult ValidationResult(string result) {
            if (result.Contains("Error404"))
            {
                return NotFound(new
                {
                    success = false,
                    errorCode = 404,
                    message = result
                });
            }

            if (result.Contains("Error"))
            {
                return BadRequest(new
                {
                    success = false,
                    errorCode = 400,
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
