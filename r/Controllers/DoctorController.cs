using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DoctorAppointment.Common.Helpers;
using DoctorAppointment.Common.Models;
using DoctorAppointment.Common.Response;
using DoctorAppointment.Common.Interfaces;
using DoctorAppointment.DataAccess;

namespace DoctorAppointment.Controllers
{
    [ApiVersion(VersionProvider.V1)]
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> _logger;
        private readonly IDoctorProfile _doctorProfile;
        private DataContext _context;
        public DoctorController(ILogger<DoctorController> logger,IDoctorProfile doctorProfile, [FromServices] DataContext context)
        {
            _logger = logger;
            _doctorProfile = doctorProfile;
            _context = context;          
        }

        [HttpGet]
        [Route("Get")] // concatenates with the route above
        public async Task<ActionResult<List<DoctorModel>>> GetAction()
        {
            var doctorModel = await _context.DoctorModel.ToListAsync();
            return Ok(doctorModel);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> DoctorProfile( DoctorModel doctorModel)
        {
            if(doctorModel == null)
            {
                throw new ArgumentNullException(nameof(doctorModel));
            }
            var result = await _doctorProfile.CreateDoctorProfile(doctorModel);
            return Ok(result);
        }
    }
}