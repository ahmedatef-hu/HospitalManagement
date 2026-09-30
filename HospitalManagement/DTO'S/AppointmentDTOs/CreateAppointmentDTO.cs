using HospitalManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.DTO_S.DoctorDTOs
{
    public class CreateAppointmentDTO
    {

        [Required]
        public DateTime AppoinmentDate { get; set; }

        [Required, MaxLength(30)]
        public string Status { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
    }
}
