using HospitalManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.DTO_S.DoctorDTOs
{
    public class GetAppointmentDTO
    {
        public int Id { get; set; }
        public DateTime AppoinmentDate { get; set; }

        public string Status { get; set; }
        public string DoctorName { get; set; }

        public string PatientName { get; set; }
    }
}
