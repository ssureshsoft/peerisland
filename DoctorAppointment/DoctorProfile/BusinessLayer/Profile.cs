using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Options;
using DoctorAppointment.DoctorProfile.Common.Interfaces;
using DoctorAppointment.Utilities.Response;
using DoctorAppointment.DoctorProfile.DataAccess;
using DoctorAppointment.DoctorProfile.Common.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.DoctorProfile.BusinessLayer
{
    public class Profile : IDoctorProfile
    {
        private readonly ILogger<Profile> _logger;
        private DataContext _context;
        private readonly IOptions<List<SpecialityModel>> _specialityModel;

        public Profile(ILogger<Profile> logger,  [FromServices] DataContext context, IOptions<List<SpecialityModel>> specialityModel)
        {
            _logger = logger;
            _context = context;
            _specialityModel = specialityModel;
        }

        public async Task<ExecutionResponse> CreateDoctorProfile(DoctorModel doctorModel)
        {
            try
            {
                if (GetDoctorInfo(doctorModel.DoctorId).Result == false)
                {
                    _context.DoctorModel.Add(doctorModel);
                    await _context.SaveChangesAsync();
                    return new ExecutionResponse(true, "Successfully Inserted", "Information");
                }
                else
                {
                    return new ExecutionResponse(false, "Doctor information exists", "Error");
                }

            }
            catch (Exception ex)
            {
                return new ExecutionResponse(false, ex.Message, "Error");
            }

        }

        public async Task<ExecutionResponse> DeleteDoctorProfile(DoctorModel doctorModel)
        {
            try
            {
                if (GetDoctorInfo(doctorModel.DoctorId).Result == true)
                {
                    _context.DoctorModel.Remove(doctorModel);
                    await _context.SaveChangesAsync();
                    return new ExecutionResponse(true, "Successfully Deleted", "Information");
                }
                else
                {
                    return new ExecutionResponse(false, "Doctor information exists", "Error");
                }

            }
            catch (Exception ex)
            {
                return new ExecutionResponse(false, ex.Message, "Error");

            }
        }

        public async Task<DoctorModel> GetDoctorById(int doctorId)
        {
            var doctorInfo = await _context.DoctorModel.ToListAsync();
            return doctorInfo.Where(x => x.DoctorId.Equals(doctorId)).FirstOrDefault();
        }

        public async Task<List<DoctorModel>> GetDoctorList()
        {
            return await _context.DoctorModel.ToListAsync();
        }

        public async Task<string> GetDoctorSpeciality(int id)
        {
            if(!_specialityModel.Value.Any())
            {
                return new ArgumentNullException(nameof(_specialityModel)).Message;
            }
            return await Task.FromResult<string>(_specialityModel.Value.Where(x=>x.SpecialityId.Equals(id)).FirstOrDefault().SpecialityName);
        }
        public async Task<ExecutionResponse> UpdateDoctorProfile(DoctorModel doctorModel)
        {
            try
            {
                if (GetDoctorInfo(doctorModel.DoctorId).Result == true)
                {
                    _context.DoctorModel.Update(doctorModel);
                    await _context.SaveChangesAsync();
                    return new ExecutionResponse(true, "Successfully Updated", "Information");
                }
                else
                {
                    return new ExecutionResponse(false, "Doctor information exists", "Error");
                }

            }
            catch (Exception ex)
            {
                return new ExecutionResponse(false, ex.Message, "Error");
            }
        }

        private async Task<bool> GetDoctorInfo(int doctorId)
        {
            var doctorInfo = await _context.DoctorModel.ToListAsync();
            var exists = doctorInfo.Where(x => x.DoctorId == doctorId);
            if (exists.Any())
                return true;

            return false;
        }

    }
}