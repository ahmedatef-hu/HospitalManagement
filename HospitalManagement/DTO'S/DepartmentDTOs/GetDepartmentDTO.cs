using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.DTO_S.DoctorDTOs
{
    public class GetDepartmentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Location { get; set; }
    }
}
