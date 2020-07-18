using System.IO;
using WorkItemGenerator.Models;
using Newtonsoft.Json;
using System.Linq;

namespace WorkItemGenerator.Services
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConfigurationService
    {
        /// <summary>
        /// Reads configuration from a file into memory.
        /// </summary>
        /// <param name="configFilePath">Location of the config file.</param>
        /// <returns></returns>
        public static ProjectConfiguration ReadConfiguration(string configFilePath)
        {
            string configurationString = File.ReadAllText(configFilePath);
            ProjectConfiguration config = JsonConvert.DeserializeObject<ProjectConfiguration>(configurationString);

            Validate(config);

            return config;
        }

        /// <summary>
        /// Writes configuration from memory into a file.
        /// </summary>
        /// <param name="configFilePath">Location of the config file.</param>
        /// <param name="configuration">Configuration to store.</param>
        public static void WriteConfiguration(string configFilePath, ProjectConfiguration configuration)
        {
            string configurationString = JsonConvert.SerializeObject(configuration);
            File.WriteAllText(configFilePath, configurationString);
        }

        /// <summary>
        /// Validates configuration file structure.
        /// </summary>
        /// <param name="configuration">Configuration instance.</param>
        private static void Validate(ProjectConfiguration configuration)
        {
            if (configuration == null)
                throw new WorkItemGeneratorException("Configuration is empty or unreadable");

            if (configuration.CollectionUri == null)
                throw new WorkItemGeneratorException("Invalid collection uri format");

            if (configuration.ProjectId == null)
                throw new WorkItemGeneratorException("Invalid project id");

            if (string.IsNullOrEmpty(configuration.ProjectName))
                throw new WorkItemGeneratorException("Project name is empty");

            if (configuration.TeamConfigurations == null)
                throw new WorkItemGeneratorException("Invalid team configuration format");

            foreach (TeamConfiguration teamConfig in configuration.TeamConfigurations)
            {
                if (teamConfig.WorkItems == null || teamConfig.WorkItems.Count == 0)
                    throw new WorkItemGeneratorException($"No WorkItems present in configuration for team {teamConfig.Name}");

                foreach (WorkItemModel workItem in teamConfig.WorkItems)
                {
                    if (workItem.CreateForEachMember && workItem.Links.Any(x => x.LinkType == LinkType.Child))
                        throw new WorkItemGeneratorException($"Work item {workItem.WorkItemType} for team {teamConfig.Name} has child items. This work item cannot be created for multiple team members");
                }
            }
        }
    }
}
