using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repos.Implementation
{
    public class PatientRepo : GenericRepo<Patient>, IPatientRepo
    {
        private readonly AppDbContext context;
        public PatientRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public Patient GethistoryAppointment(int id)
        {
            return context.Patients
                .Include(a => a.Appointments)
                .ThenInclude(d => d.Doctor)
                .FirstOrDefault(d => d.Id == id);
        }
    }
}
