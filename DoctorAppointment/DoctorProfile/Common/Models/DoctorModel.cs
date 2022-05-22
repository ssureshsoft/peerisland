using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using DoctorAppointment.Utilities;
namespace DoctorAppointment.DoctorProfile.Common.Models
{
    public class DoctorModel : BaseEntityInfo
    {
        [Key]
        public int Id { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "DoctorId is required.")]
        public int DoctorId { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public int SpecialityId { get; set; }
        public string CurrencyType { get; set; }
        public double ConsulationFee { get; set; }
        public string Rating { get; set; }
        public string Qualification { get; set; }
        public string Designation { get; set; }

        public string AppointmentStatus { get; set; }
    }
}