using HospitalManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.DTO_S.DoctorDTOs
{
    public class GetMedicalRecordDTO
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string? Notes { get; set; }
        public string AppoinmentStatus { get; set; }
    }
}
