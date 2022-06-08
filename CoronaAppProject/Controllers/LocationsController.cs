using Microsoft.AspNetCore.Mvc;
using Serilog;
using Services;
using Services.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaAppProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
            private ILocationRepository _repository;

            public LocationsController(ILocationRepository repository)
            {

                  _repository = repository;
                
        }


            // GET: api/<UsersController>
            [HttpGet]


            public async Task<List<Patient>> Get()
            {
           
            var locations = await Task.FromResult(_repository.GetLocations());
                return await locations;

            }


            // GET api/<UsersController>/city
            [HttpGet("{city}")]
            public async Task<List<Location>> GetLocation(string city)
            {
           
            List<Location> locations = await _repository.GetLocation(city);
                return locations;
            }


            // POST api/<UsersController>
            [HttpPost]
            public void Post(int id, Location newLocation)
            {
            _repository.AddLocation(id, newLocation);
            }


        }
    }
