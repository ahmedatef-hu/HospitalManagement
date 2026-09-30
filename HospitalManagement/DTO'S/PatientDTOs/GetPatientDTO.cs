using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.DTO_S.DoctorDTOs
{
    public class GetPatientDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
    }
}
