using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DoctorAppointment.Utilities;
using DoctorAppointment.DoctorProfile.Common.Interfaces;
using DoctorAppointment.DoctorProfile.DataAccess;
using DoctorAppointment.DoctorProfile.Common.Models;
using DoctorAppointment.Utilities.Response;
namespace DoctorAppointment.DoctorProfile.Controllers
{
    [ApiVersion(VersionProvider.V1)]
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> _logger;
        private readonly IDoctorProfile _doctorProfile;
        private DataContext _context;
        public DoctorController(ILogger<DoctorController> logger,IDoctorProfile doctorProfile,
         [FromServices] DataContext context)
        {
            _logger = logger;
            _doctorProfile = doctorProfile;
            _context = context;
        }

        [HttpGet]
        [Route("Get")] // concatenates with the route above
        public async Task<ActionResult> GetDoctorList()
        {
            var doctorModel = await _doctorProfile.GetDoctorList();
            return Ok(doctorModel);
        }

        [HttpGet]
        [Route("{Id}")] // concatenates with the route above
        public async Task<ActionResult> GetDoctorById(int doctorId)
        {
            if(doctorId == 0)
            {
                return BadRequest("Invalid doctorId");
            }
            var result = await _doctorProfile.GetDoctorById(doctorId);
            return Ok(result);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> DoctorProfile(DoctorModel doctorModel)
        {
            ExecutionResponse response = ValidateModel(doctorModel).Result;
            if(response.Ok)
            {
                var result = await _doctorProfile.CreateDoctorProfile(doctorModel);
                return Ok(result);
            }
            else
            {
                return BadRequest(response);
            }
        }


        private async Task<ExecutionResponse> ValidateModel(DoctorModel doctorModel)
        {
            ExecutionResponse response = new ExecutionResponse();
            var messages = new Dictionary<string,object>();

            if(doctorModel == null)
            {
                return new ExecutionResponse(false, new ArgumentNullException(nameof(doctorModel)).Message);
            }
             if(doctorModel.SpecialityId.Equals(0))
            {
               messages.Add(nameof(doctorModel.SpecialityId) ,string.Format("Invalid {0}",nameof(doctorModel.SpecialityId)));
            }
            if(!doctorModel.SpecialityId.Equals(0))
            {
                if(string.IsNullOrEmpty(_doctorProfile.GetDoctorSpeciality(doctorModel.SpecialityId).Result))
                {
                    messages.Add(nameof(doctorModel.SpecialityId) ,string.Format("Doesn't exists {0} SpecialityId",nameof(doctorModel.SpecialityId)));
                }
            }
            if(doctorModel.DoctorId.Equals(0))
            {
               messages.Add(nameof(doctorModel.DoctorId) ,string.Format("{0} is default value. It should more than zero.",nameof(doctorModel.DoctorId)));
            }
            if(string.IsNullOrEmpty(doctorModel.FirstName))
            {
               messages.Add(nameof(doctorModel.FirstName) ,string.Format("{0} is null",nameof(doctorModel.FirstName)));
            }
            if(string.IsNullOrEmpty(doctorModel.LastName))
            {
               messages.Add(nameof(doctorModel.LastName) ,string.Format("{0} is null",nameof(doctorModel.LastName)));
            }
            if(string.IsNullOrEmpty(doctorModel.Designation))
            {
               messages.Add(nameof(doctorModel.Designation) ,string.Format("{0} is null",nameof(doctorModel.Designation)));
            }
             if(string.IsNullOrEmpty(doctorModel.Qualification))
            {
               messages.Add(nameof(doctorModel.Qualification) ,string.Format("{0} is null",nameof(doctorModel.Qualification)));
            }
           
            if(messages.Any())
            {   
                response.Ok = false;
                response.Payload = messages;
            }
            else
            {
                response.Ok = true;
            }
            return await Task.FromResult<ExecutionResponse>(response);
        }
    }
}