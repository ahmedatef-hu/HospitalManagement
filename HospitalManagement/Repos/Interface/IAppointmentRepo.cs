using HospitalManagement.Models;

namespace HospitalManagement.Repos.Interface
{
    public interface IAppointmentRepo : IGenericRepo<Appointment>
    {
        List<Appointment> GetAppointmentsToday();
    }
}
