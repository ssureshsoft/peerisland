using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointment.DoctorProfile.Common.Models
{
     public class AvailablityModel
    {
        [Key]
        public int Id { get; set; }
        
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "DoctorId is required.")]
        public int DoctorId { get; set; }
        public DateTime AppointmentDate {get;set;}
        public DateTime StartTime {get;set;}
        public DateTime EndTime {get;set;}

    }
}