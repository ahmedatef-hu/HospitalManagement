using HospitalManagement.Data;
using HospitalManagement.Repos.Interface;

namespace HospitalManagement.Repos.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public IDoctorRepo DoctorRepo { get; }

        public IDepartmentRepo DepartmentRepo { get; }

        public IPatientRepo PatientRepo { get; }

        public IAppointmentRepo AppointmentRepo { get; }
        public UnitOfWork(AppDbContext context, IDoctorRepo doctorRepo, IDepartmentRepo departmentRepo, IPatientRepo patientRepo, IAppointmentRepo appointmentRepo)
        {
            this.context = context;
            DoctorRepo = doctorRepo;
            DepartmentRepo = departmentRepo;
            PatientRepo = patientRepo;
            AppointmentRepo = appointmentRepo;
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
