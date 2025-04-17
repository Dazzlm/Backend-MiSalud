using Backend_MiSalud.Clases;
using Backend_MiSalud.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MiSalud.Controllers
{
    [ApiController]
    [Route("api/Doctor")]

    public class DoctorController : ControllerBase
    {
        [HttpGet]
        [Route("GetDoctors")]
        public IActionResult GetDoctors()
        {
            ClsDoctor clsDoctor = new ClsDoctor();
            List<Doctor> doctors = clsDoctor.GetDoctors();
            if (doctors == null || doctors.Count == 0)
            {
                return NotFound(new
                {
                    success = false,
                    message = "No se encontraron doctores"
                });
            }

            return Ok(new
            {
                success = true,
                data = doctors
            });
        }

        [HttpGet]
        [Route("GetDoctorsById/{id}")]
        public IActionResult GetDoctorsById(int id)
        {

            ClsDoctor clsDoctor = new ClsDoctor();
            Doctor doctor = clsDoctor.GetDoctorById(id);

            if (doctor == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Doctor no encontrado."
                });
            }

            return Ok(new
            {
                success = true,
                data = doctor
            });


        }
    }
}
