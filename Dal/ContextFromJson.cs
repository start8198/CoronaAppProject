using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Dal
{
    public class ContextFromJson
    {
        public List<Patient> Patients { get; set; }
        public ContextFromJson()
        {
            using (StreamReader reader = new StreamReader("Context.json"))
            {
                string json = reader.ReadToEnd();
                Patients = JsonSerializer.Deserialize<List<Patient>>(json);
            }
        }
    }
}
