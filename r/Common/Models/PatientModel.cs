using System;
using DoctorAppointment.Common.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DoctorAppointment.Common.Models
{
    //[Keyless]
    public class PatientModel : BaseEntityInfo
    {
        [Key]
        public int Id {get; set;}
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]        
        private int PatientId { get; set; }        
        private DateTime AppointmentDate { get; set; }
    }
}