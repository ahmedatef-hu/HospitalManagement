using HospitalManagement.Models;

namespace HospitalManagement.Repos.Interface
{
    public interface IDepartmentRepo : IGenericRepo<Department>
    {
        List<Department> GetDepartmentsWithDoctorCount();
    }
}
