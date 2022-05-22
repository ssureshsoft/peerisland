using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DoctorAppointment.DoctorProfile.Common.Models
{
    public class SpecialityModel
    {
        [Key]
        public int Id {get; set;}
        
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]     
        [Required(ErrorMessage = "SpecialityId is required.")]
        public int SpecialityId { get; set; }
        public string SpecialityName { get; set; }
    }
}