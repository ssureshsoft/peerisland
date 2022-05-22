using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DoctorAppointment.Common.Models
{
    internal class SpecialityModel
    {
        [Key]
        public int Id {get; set;}
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]        
        private int SpecialityId { get; set; }
        private string Speciality { get; set; }
    }
}