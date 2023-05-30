using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Models
{
    internal class Lib
    {
        public static UserConfig config;
        private static string configFilePath = "config.json";
        public  Lib()
        {

        }

        public static void Init()
        {

        }

        public static void LoadConfig()
        {
            string configFilePath = GetConfigPath();

            if (File.Exists(configFilePath))
            {
                string json = File.ReadAllText(configFilePath);
                config = JsonConvert.DeserializeObject<UserConfig>(json);
            }
            else
            {
                config = new UserConfig();
            }
        }

        public static void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(config);
            File.WriteAllText(GetConfigPath(), json);
        }


        public static string GetConfigPath()
        {
            return Path.Combine(FileSystem.AppDataDirectory, configFilePath);
        }
    }
}
