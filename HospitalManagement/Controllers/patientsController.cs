using HospitalManagement.DTO_S.DoctorDTOs;
using HospitalManagement.Models;
using HospitalManagement.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class patientsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public patientsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Create(CreatePatientDTO patientDTO)
        {
            var patient = new Patient
            {
                FullName = patientDTO.FullName,
                Address = patientDTO.Address,
                DateOfBirth = DateTime.UtcNow,
                Gender = patientDTO.Gender,
                Phone = patientDTO.Phone,
            };
            unitOfWork.PatientRepo.Create(patient);
            unitOfWork.Save();
            return Created();
        }
        [HttpGet]
        public IActionResult GetAllPatient()
        {
            var patients = unitOfWork.PatientRepo.GetAll();
            var result = patients.Select(s => new
            {
                FullName = s.FullName,
                Address = s.Address,
                DateOfBirth = DateTime.UtcNow,
                Gender = s.Gender,
                Phone = s.Phone,
            }).ToList();
            return Ok(result);
        }
        [HttpGet("history/{id}")]
        public IActionResult GetPatientHistory(int id)
        {
            var patient = unitOfWork.PatientRepo.GethistoryAppointment(id);
            var result = new
            {
                FullName = patient.FullName,
                Address = patient.Address,
                DateOfBirth = DateTime.UtcNow,
                Gender = patient.Gender,
                Phone = patient.Phone,
                Appointments = patient.Appointments.Select(a => new
                {
                    Id = a.Id,
                    AppoinmentDate = a.AppoinmentDate,
                    Status = a.Status,
                    DoctorName = a.Doctor.FullName,
                    DoctorSpecialization = a.Doctor.Specialization
                }) 
            };
            return Ok(result);
        }
    }
}
