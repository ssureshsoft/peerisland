using System;
using DoctorAppointment.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DoctorAppointment.DoctorProfile.Common.Models
{
    public class PatientModel : BaseEntityInfo
    {
        [Key]
        public int Id {get; set;}
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]      
        [Required(ErrorMessage = "PatientId is required.")]
        private int PatientId { get; set; }        
        private DateTime AppointmentDate { get; set; }
    }
}