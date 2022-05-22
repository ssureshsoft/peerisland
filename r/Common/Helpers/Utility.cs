using System;
using DoctorAppointment.Common.Enum;
namespace DoctorAppointment.Common.Helpers
{
    public class Utility
    {

        public static bool IsDateTime(string inputDate, String type)
        {
            DateTime fromDateValue;
            var formats = new[] {""};
            if(type ==  Enum.DateType.DOB.ToString())
            { 
                formats = new[] { "dd/MM/yyyy"}; 
            }
            else 
            {
               formats = new[] { "dd/MM/yyyy hh:mm tt" };
            }
            return DateTime.TryParseExact(inputDate, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue);
        }
    }
}