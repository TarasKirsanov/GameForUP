using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Rabbit__Game
{
    static class JSONWorker
    {
        public static void WriteFile(Configarithion conf)
        {
            string path = $"{Directory.GetCurrentDirectory()}\\Setting.json";
            using (var writer = new StreamWriter(path, false))
            {
                string json = JsonConvert.SerializeObject(conf, formatting: Formatting.Indented);
                writer.Write(json);
            }
        }

        public static Configarithion GetList()
        {
            string jsonString = File.ReadAllText("Setting.json");
            return JsonConvert.DeserializeObject<Configarithion>(jsonString);
        }
    }
}
