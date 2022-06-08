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
    public class LocationRepository : ILocationRepository
    {
        private ContextFromJson _Db ;

        public LocationRepository()
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            _Db = new ContextFromJson();
        }


        public async Task<List<Patient>> GetLocations()
        {
            Log.Logger.Information("GetLocations from LocationController called");
            return await Task.FromResult(_Db.Patients);
        }


        public async Task<List<Location>> GetLocation(string city)

        {
            Log.Logger.Information($"GetLocation from LocationController called with city:{city}");
            List<Location> LocationsList = _Db.Patients.SelectMany(p => p.Locations).ToList();
            return await Task.FromResult(LocationsList.Where(l => l.City.Equals(city)).ToList());
            
        }

        public async Task<Patient> AddLocation(int id, Location location)
        {
            Patient p = _Db.Patients.Where(patient => patient.Id == id).FirstOrDefault();
            if (p == null)
                Log.Logger.Error($"AddLocation from LocationController with {id} and didn't found");
            else {
                p.Locations.Add(location);
                WritingToJson.WriteToJsonFile(_Db.Patients, "context.json");
                Log.Logger.Information($"AddLocation from LocationController added successfully new location {location} to:{ id}");
        }
           
            return await Task.FromResult(p);

        }
    }
}
