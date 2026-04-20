using Microsoft.AspNetCore.Mvc;
using PatientManagement.Entities;
using PatientManagement.Services;
namespace PatientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentAPIController:ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentAPIController(IAppointmentService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var data = await _service.GetAppointments();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(Appointment appointment)
        {
            var created = await _service.CreateAppointment(appointment);
            return Ok(created);
        }
        [HttpGet("AppointmentsByDoctor/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsByDoctor(int doctorId)
        {
            var data = await _service.GetAppointmentsByDoctor(doctorId);
            return Ok(data);
        }
    }
}
