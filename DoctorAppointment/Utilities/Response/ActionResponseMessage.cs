using System;
namespace DoctorAppointment.Utilities.Response
{
    public class ActionResponseMessage
    {
        public string Message { get; set; }

        public string Type { get; set; }

        public ActionResponseMessage(string message, string type)
        {
            Message = message;
            Type = type;
        }
    }
}