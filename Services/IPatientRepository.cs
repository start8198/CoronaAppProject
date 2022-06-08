using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPatientRepository
    {
        public Task<List<Location>> GetLocations(int patientId);
        public Task<Patient> AddPatient(Patient patient);
    }
}
