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
                return NotFound("Paciente no encontrado.");
            }
            return Ok(patient);
        }
        [HttpGet]
        [Route("GetPatientByCedula/{cedula}")]
        public IActionResult GetPatientByCedula(string cedula)
        {
            ClsPatient clsPatient = new ClsPatient();
            Patient patient = clsPatient.GetAppointmentsByCedula(cedula);
            if (patient == null)
            {
                return NotFound("Paciente no encontrado.");
            }
            return Ok(patient);
        }

        [HttpPost]
        [Route("AddPatient")]
        public IActionResult AddPatient([FromBody] Patient patient)
        {
            ClsPatient clsPatient = new ClsPatient();
            string result = clsPatient.AddPatient(patient);
            if (result.Contains("Error"))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeletePatient/{id}")]
        public IActionResult DeletePatient(int id)
        {
            ClsPatient clsPatient = new ClsPatient();
            string result = clsPatient.DeleteAppointment(id);
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
