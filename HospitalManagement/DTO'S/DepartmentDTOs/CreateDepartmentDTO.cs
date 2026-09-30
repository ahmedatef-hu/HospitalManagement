using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.DTO_S.DoctorDTOs
{
    public class CreateDepartmentDTO
    {

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(150)]
        public string? Location { get; set; }
    }
}
