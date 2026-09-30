namespace HospitalManagement.Repos.Interface
{
    public interface IUnitOfWork
    {
        IDoctorRepo DoctorRepo { get; }
        IDepartmentRepo DepartmentRepo { get; }
        IPatientRepo PatientRepo { get; }
        IAppointmentRepo AppointmentRepo { get; }
        int Save();
    }
}
