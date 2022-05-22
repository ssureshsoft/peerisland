using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Utilities.Response;
using DoctorAppointment.DoctorProfile.Common.Models;
namespace DoctorAppointment.DoctorProfile.Common.Interfaces
{
    public interface IDoctorProfile
    {
        Task<ExecutionResponse> CreateDoctorProfile(DoctorModel model);
        Task<ExecutionResponse> UpdateDoctorProfile(DoctorModel doctorModel);
        Task<ExecutionResponse> DeleteDoctorProfile(DoctorModel doctorModel);

        Task<List<DoctorModel>> GetDoctorList();
        Task<DoctorModel> GetDoctorById(int doctorId);
        Task<string> GetDoctorSpeciality(int id);
        
    }
}