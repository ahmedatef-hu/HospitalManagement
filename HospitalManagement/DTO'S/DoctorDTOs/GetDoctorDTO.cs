using HospitalManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.DTO_S.DoctorDTOs
{
    public class GetDoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }

        public string DepartmentName { get; set; }
    }
}
