using System;
using Microsoft.EntityFrameworkCore;
using DoctorAppointment.Common.Models;

namespace DoctorAppointment.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<DoctorModel> DoctorModel { get; set;}
        public DbSet<PatientModel> PatientModel { get; set; }

    }
}