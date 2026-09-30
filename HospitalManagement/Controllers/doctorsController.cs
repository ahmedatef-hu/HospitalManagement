using HospitalManagement.DTO_S.DoctorDTOs;
using HospitalManagement.Models;
using HospitalManagement.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class doctorsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public doctorsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult Create(CreateDoctorDTO doctor)
        {
            var newdoc = new Doctor
            {
                FullName = doctor.FullName,
                Email = doctor.Email,
                Phone = doctor.Phone,
                Salary = doctor.Salary,
                Specialization = doctor.Specialization,
                DepartmentId = doctor.DepartmentId,
            };
            unitOfWork.DoctorRepo.Create(newdoc);
            unitOfWork.Save();
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult Update(CreateDoctorDTO doctor)
        {
            var newdoc = new Doctor
            {
                FullName = doctor.FullName,
                Email = doctor.Email,
                Phone = doctor.Phone,
                Salary = doctor.Salary,
                Specialization = doctor.Specialization,
                DepartmentId = doctor.DepartmentId,
            };
            unitOfWork.DoctorRepo.Create(newdoc);
            unitOfWork.Save();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var doctor = unitOfWork.DoctorRepo.GetById(id);
            unitOfWork.DoctorRepo.Delete(doctor);
            unitOfWork.Save();
            return Ok();
        }

        [HttpGet("specialization/{specialization}")]
        public IActionResult GetByspecialization(string specialization)
        {
            var doctors = unitOfWork.DoctorRepo.GetBySpecialization(specialization);

            var result = doctors.Select(s => new 
            {
                Id = s.Id,
                FullName = s.FullName,
                Email = s.Email,
                Phone = s.Phone,
                Salary = s.Salary,
                Specialization = specialization,
                DepartmentId = s.DepartmentId,
            }).ToList();
            return Ok(result);
        }
        [HttpGet("details")]
        public IActionResult details()
        {
            var doctors = unitOfWork.DoctorRepo.GetDetials();

            var result = doctors.Select(s => new
            {
                Id = s.Id,
                FullName = s.FullName,
                Email = s.Email,
                Phone = s.Phone,
                Salary = s.Salary,
                Specialization = s.Specialization,
                DepartmentName = s.Department.Name,
            }).ToList();
            return Ok(result);
        }
    }
}
