using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services
{
    public class WritingToJson
    {
        public static void WriteToJsonFile(object obj, string fileNmae)
        {
            string Context = JsonSerializer.Serialize(obj, new JsonSerializerOptions() { WriteIndented = true });
            using (StreamWriter outputFile = new StreamWriter(fileNmae))
            {
                outputFile.WriteLine(Context);
            }
        }
    }
}
