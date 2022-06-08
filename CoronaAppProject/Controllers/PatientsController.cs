using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaAppProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private IPatientRepository _repository;
        public PatientsController(IPatientRepository repository)
        {
            _repository = repository;
        }

        // GET api/<UsersController>/5
        [HttpGet("{patientId}")]
        public async Task<List<Location>> GetLocationAsync(int patientId)
        {
            return await await Task.FromResult(_repository.GetLocations(patientId));
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post(Patient patient)
        {
            _repository.AddPatient(patient);
        }
    }
}
