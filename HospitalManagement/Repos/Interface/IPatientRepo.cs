using HospitalManagement.Models;

namespace HospitalManagement.Repos.Interface
{
    public interface IPatientRepo : IGenericRepo<Patient>
    {
        Patient GethistoryAppointment(int id);
    }
}
