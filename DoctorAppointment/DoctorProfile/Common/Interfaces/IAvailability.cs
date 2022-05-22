using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace DoctorAppointment.DoctorProfile.Common.Interfaces
{
    public interface IAvailability
    {
        Task<List<DateTime>> GetAvailablity(string DdoctorId);

    }
}