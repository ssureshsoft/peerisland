using System;
using System.Collections;
using System.Collections.Generic;
namespace DoctorAppointment.Utilities.Response
{
    public class ExecutionResponse
    {
        public bool Ok { get; set; }
        public List<ActionResponseMessage> Messages { get; set; }
        public Dictionary<string, object> Payload { get; set; }

        public ExecutionResponse()
        {

        }

        public ExecutionResponse(bool ok, string msg, string msgType=null)
        {
            Ok = ok;
            Messages = new List<ActionResponseMessage> {
                new ActionResponseMessage(msg, msgType)
            };
        }
        public ExecutionResponse(bool ok, Dictionary<string, object> payload)
        {
            Ok = ok;
            Payload = payload;
        }

        public ExecutionResponse(bool ok, Dictionary<string, object> payload, List<ActionResponseMessage> messages)
        {
            Ok = ok;
            Payload = payload;
            Messages = messages;
        }
    }
}