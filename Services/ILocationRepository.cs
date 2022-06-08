using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ILocationRepository
    {
        public Task<List<Patient>> GetLocations();
        public Task<List<Location>> GetLocation(string city);
        public Task<Patient> AddLocation(int id, Location location);
    }
}
