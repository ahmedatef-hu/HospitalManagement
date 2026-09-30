using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.DTO_S.DoctorDTOs
{
    public class CreatePatientDTO
    {

        [Required, MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Phone]
        [Required, MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }
    }
}
