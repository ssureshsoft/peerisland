using System.Security.AccessControl;
using System;
using DoctorAppointment.Common.Interfaces;
using DoctorAppointment.Common.Models;
using DoctorAppointment.Common.Response;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DoctorAppointment.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace DoctorAppointment.BusinessLayer
{
    public class DoctorProfile : IDoctorProfile
    {
        private readonly ILogger<DoctorProfile> _logger;
        private DataContext _context;

        public DoctorProfile(ILogger<DoctorProfile> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<ExecutionResponse> CreateDoctorProfile(DoctorModel doctorModel)
        {
            try
            {
                if(GetDoctorInfo(doctorModel.DoctorId).Result == false)
                {
                    _context.DoctorModel.Add(doctorModel);
                     await _context.SaveChangesAsync();
                    return new ExecutionResponse(true,"Successfully Inserted", "Information");
                }
                else
                {
                    return new ExecutionResponse(false,"Doctor information exists", "Error");
                }

            }
            catch (Exception ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
           
        }

        private async Task<bool> GetDoctorInfo(int doctorId)
        {
            var doctorInfo = await _context.DoctorModel.ToListAsync();
            var exists = doctorInfo.Where(x => x.DoctorId == doctorId);
            if(exists.Any())
                return true;

            return false;
        }

    }
}