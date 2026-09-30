
using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Repos.Implementation;
using HospitalManagement.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("defualtConnection")));
            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));

            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();

            builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();

            builder.Services.AddScoped<IPatientRepo, PatientRepo>();

            builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
