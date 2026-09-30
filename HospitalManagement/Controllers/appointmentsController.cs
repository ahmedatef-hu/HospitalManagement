using HospitalManagement.DTO_S.DoctorDTOs;
using HospitalManagement.Models;
using HospitalManagement.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class appointmentsController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public appointmentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpPost("book")]
        public IActionResult Create(CreateAppointmentDTO appointmentDTO)
        {
            var newappointment = new Appointment
            {
                DoctorId = appointmentDTO.DoctorId,
                PatientId = appointmentDTO.PatientId,
                Status = appointmentDTO.Status,
                AppoinmentDate = appointmentDTO.AppoinmentDate,
            };
            unitOfWork.AppointmentRepo.Create(newappointment);
            unitOfWork.Save();
            return Created();
        }
        [HttpGet("today")]
        public IActionResult today()
        {
            var appointments = unitOfWork.AppointmentRepo.GetAppointmentsToday();
            var result = appointments.Select(a => new
            {
                Id = a.Id,
                patientName = a.Patient.FullName,
                DoctorName = a.Doctor.FullName,
                Status = a.Status,
                appointmentdate = a.AppoinmentDate
            }).ToList();

            return Ok(result);
        }
    }
}
