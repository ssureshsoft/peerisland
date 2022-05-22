using System;
using Microsoft.EntityFrameworkCore;
using DoctorAppointment.DoctorProfile.Common.Models;

namespace DoctorAppointment.DoctorProfile.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<DoctorModel> DoctorModel { get; set;}

    }
}