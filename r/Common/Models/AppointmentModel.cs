using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DoctorAppointment.Common.Models
{
    public class AppointmentModel
    {
        [Key]
        public int Id {get; set;}

        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        private int AppointmentId { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]  
        private int DoctorId { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]  
        private int PatientId { get; set; }   
        
        private DateTime StatDateTime { get; set; }
        private DateTime EndDateTime { get; set; }
        private string Status { get; set; }
        private DateTime BookedDate { get; set; }
    }
}