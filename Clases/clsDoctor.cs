using Backend_MiSalud.Models;

namespace Backend_MiSalud.Clases
{
    public class ClsDoctor
    {
        private readonly MiSaludContext dbMiSalud = new MiSaludContext();

        public Doctor GetDoctorById(int doctorId)
        {
            return dbMiSalud.Doctors.FirstOrDefault(d => d.IdDoctor ==doctorId);
        }

        public List<Doctor> GetDoctors()
        {
            return dbMiSalud.Doctors.ToList();
        }

    }
}
