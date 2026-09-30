using HospitalManagement.DTO_S.DoctorDTOs;
using HospitalManagement.Models;
using HospitalManagement.Repos.Implementation;
using HospitalManagement.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class departmentsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public departmentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = unitOfWork.DepartmentRepo.GetAll();
            var result = departments.Select(
                d => new
                {
                    Id = d.Id,
                    Name = d.Name,
                    Location = d.Location
                }
            );
            return Ok( result );
        }
        [HttpGet("doctor-count")]
        public IActionResult GetDepartmentsDoctorCount()
        {
            var department = unitOfWork.DepartmentRepo.GetDepartmentsWithDoctorCount();
            var result = department.Select(
                d => new
                {
                    Id = d.Id,
                    Name = d.Name,
                    Location = d.Location,
                    DoctorCount = d.Doctors.Count()
                }
            );
            return Ok( result );
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDTO department)
        {
            var newdept = new Department
            {
                Name = department.Name,
                Location = department.Location
            };
            unitOfWork.DepartmentRepo.Create(newdept);
            unitOfWork.Save();
            return Created();
        }
    }
}
