using Serilog;
using Services;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class PatientRepository : IPatientRepository
    {
        private ContextFromJson _Db;

        public PatientRepository()
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            _Db = new ContextFromJson();
        }

        public async Task<List<Location>> GetLocations(int patientId)
        {
            Log.Logger.Information($"GetLocation from LocationController called with Id:{patientId}");
            Patient p =await Task.FromResult( _Db.Patients.Where(p1 => p1.Id == patientId).FirstOrDefault());
            return p!=null?p.Locations:null;
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
                _Db.Patients.Add(patient);
                WritingToJson.WriteToJsonFile(_Db.Patients, "context.json");
                Log.Logger.Information($"AddPatient from PatientController added successfully new patient {patient} ");
            

            return await Task.FromResult(patient);

        }
    }
}
