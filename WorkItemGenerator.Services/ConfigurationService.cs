using System;
using System.IO;
using WorkItemGenerator.Models;
using Newtonsoft.Json;

namespace WorkItemGenerator.Services
{
    public static class ConfigurationService
    {
        public static ProjectConfiguration ReadConfiguration(string configFilePath)
        {
            string configurationString = File.ReadAllText(configFilePath);
            return JsonConvert.DeserializeObject<ProjectConfiguration>(configurationString);
        }

        public static void WriteConfiguration(string configFilePath, ProjectConfiguration configuration)
        {
            string configurationString = JsonConvert.SerializeObject(configuration);
            File.WriteAllText(configFilePath, configurationString);
        }
    }
}
