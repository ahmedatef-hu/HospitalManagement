using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repos.Implementation
{
    public class AppointmentRepo : GenericRepo<Appointment>, IAppointmentRepo
    {
        private readonly AppDbContext context;
        public AppointmentRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public List<Appointment> GetAppointmentsToday()
        {
            var today = DateTime.Today;
            return context.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .Where(d => d.AppoinmentDate ==  today).ToList();
        }
    }
}
