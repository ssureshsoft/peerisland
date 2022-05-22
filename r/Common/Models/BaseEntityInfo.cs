using System;
using DoctorAppointment.Common.Enum;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
namespace DoctorAppointment.Common.Models
{
    public class BaseEntityInfo
    {
        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "EmailId is not valid.")]
        private string EmailId { get; set; }

        private Gender Gender { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]        
        private int Age { get; set; }

        private DateTime DoB { get; set; }

        private string Address { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid mobile Number")]        
        private int MobileNumber { get; set; }
    }
}