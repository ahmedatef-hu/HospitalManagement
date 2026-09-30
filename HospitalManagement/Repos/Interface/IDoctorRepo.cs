using HospitalManagement.Models;

namespace HospitalManagement.Repos.Interface
{
    public interface IDoctorRepo : IGenericRepo<Doctor>
    {
        List<Doctor> GetBySpecialization(string specialization);
        List<Doctor> GetDetials();
    }
}
