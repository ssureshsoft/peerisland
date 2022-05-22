using System;
using DoctorAppointment.Common.Response;
using DoctorAppointment.Common.Models;
using System.Threading.Tasks;
namespace DoctorAppointment.Common.Interfaces
{
    public interface IDoctorProfile
    {
        Task<ExecutionResponse> CreateDoctorProfile(DoctorModel doctorModel);
    }
}