
using PatientManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PatientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientManagementAPIController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientManagementAPIController(IPatientService patientService)
        {
            this._patientService = patientService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {

            var data = await _patientService.GetPatients();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientById(id);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePatient(Patient pat)
        {
            var created = await _patientService.CreatePatient(pat);
            return Ok(created);
            // return CreatedAtAction(nameof(GetPatientById), new { id = created.PatientId }, created);    -> Ye REST standard hai (interview me bhi poocha jata hai)
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, Patient pat)
        {
            var updated = await _patientService.UpdatePatient(id, pat);

            if (updated == null)
                return NotFound();

            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var deleted = await _patientService.DeletePatient(id);

            if (deleted == null)
                return NotFound();

            return Ok();
            //return NoContent();  -> Standard REST response for delete
        }
    }
}
