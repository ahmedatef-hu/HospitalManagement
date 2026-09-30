using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repos.Implementation
{
    public class DoctorRepo : GenericRepo<Doctor>, IDoctorRepo
    {
        private readonly AppDbContext context;
        public DoctorRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public List<Doctor> GetBySpecialization(string specialization)
        {
            return context.Doctors.Where(s => s.Specialization == specialization).ToList();
        }

        public List<Doctor> GetDetials()
        {
            return context.Doctors.Include(d => d.Department).ToList();
        }
    }
}
