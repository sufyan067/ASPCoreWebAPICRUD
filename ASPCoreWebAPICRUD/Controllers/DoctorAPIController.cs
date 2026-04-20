using Microsoft.AspNetCore.Mvc;
using PatientManagement.Entities;
using PatientManagement.Services;
namespace PatientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAPIController:ControllerBase
    {
        private readonly IDoctorService _service;
        public DoctorAPIController(IDoctorService service)
        {
            _service = service;

        }
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var data = await _service.GetDoctors();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(Doctor doctor)
        {
            var created = await _service.CreateDoctor(doctor);
            return Ok(created);
        }
    }
}
