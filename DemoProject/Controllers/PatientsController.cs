using DemoProject.Models;
using DemoProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly PatientDbContext _context;
        public PatientsController(PatientDbContext context, IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
        }

        [HttpPost("savepatient")]
        public async Task<IActionResult> SavePatient([FromBody] PatientModel model)
        {
            var result = await _patientService.SavePatient(model);
            if (result>0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("deletepatient/{patientId}")]
        public async Task<IActionResult> DeletePatient(int patientId)
        {
            var result = await _patientService.DeletePatient(patientId);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("allpatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var result = await _patientService.GetAllPatientsAsync();
            if (result!=null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("getpatientdetails/{patientId}")]
        public async Task<IActionResult> GetPatientById(int patientId)
        {
            var result = await _patientService.GetPatinetById(patientId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
