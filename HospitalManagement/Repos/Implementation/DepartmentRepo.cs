using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repos.Implementation
{
    public class DepartmentRepo : GenericRepo<Department>, IDepartmentRepo
    {
        private readonly AppDbContext _context;

        public DepartmentRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public List<Department> GetDepartmentsWithDoctorCount()
        {
            return _context.Departments.Include(d => d.Doctors).ToList();
        }
    }
}
