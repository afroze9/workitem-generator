using System;
using System.IO;
using Xunit;
using WorkItemGenerator.Models;
using WorkItemGenerator.Services;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WorkItemGenerator.Tests
{
    public class ConfigurationServiceTests
    {
        private static readonly string TestConfigurationFile = "test-config.json";
        private ProjectConfiguration GetTestConfiguration()
        {
            return new ProjectConfiguration()
            {
                CollectionUri = new Uri(@"https://dev.azure.com/afroze-tutorials/"),
                ProjectId = new Guid("466638E3-FCDD-421F-891F-A5BA8F9E55EB"),
                ProjectName = "Project Name",
                TeamConfigurations = new List<TeamConfiguration>()
                {
                    new TeamConfiguration()
                    {
                        DefaultAreaPath = "Project Name\\Area A",
                        ID = new Guid("B3F54111-C63D-4070-BDDD-BCC096826756"),
                        IterationsProcessed = new List<Iteration>()
                        {
                            new Iteration() { IterationID = new Guid("BEE36F19-DDA1-4FEB-A682-FF178BA216BD"), IterationPath = "Project Name\\Iteration 1" },
                            new Iteration() { IterationID = new Guid("A5A3ABE3-6A77-487A-92F6-6BB6B3770486"), IterationPath = "Project Name\\Iteration 2" }
                        },
                        IterationsToIgnore = new List<Iteration>()
                        {
                            new Iteration() { IterationID = new Guid("61770D6B-B140-435B-AC61-015D1E92C585"), IterationPath = "Project Name\\Iteration 3" }
                        },
                        Name = "Team A",
                        WorkItems = new List<WorkItemModel>()
                        {
                            new WorkItemModel()
                            {
                                FieldValues = new Dictionary<string, object>()
                                {
                                    {"System.Title", "Test Meeting"},
                                    {"System.Description", "This is a test meeting"}
                                },
                                Links = new List<WorkItemLink>()
                                {
                                    new WorkItemLink()
                                    {
                                        LinkedWorkItem = new WorkItemModel()
                                        {
                                            FieldValues = new Dictionary<string, object>()
                                            {
                                                {"System.Title", "Test Task"},
                                                {"System.Description", "This is a test child task for the meeting"},
                                                {"System.AssignedTo", "Afroze Amjad"},
                                            },
                                            Links = null,
                                            WorkItemType = WorkItemType.Task
                                        },
                                        LinkType = LinkType.Child
                                    }
                                },
                                WorkItemType = WorkItemType.Meeting
                            }
                        }
                    }
                },
            };
        }

        [Fact]
        public void ReadConfigurationShouldReadConfigurationFileIntoObject()
        {
            ProjectConfiguration configuration = ConfigurationService.ReadConfiguration(TestConfigurationFile);
            Assert.NotNull(configuration);
        }

        [Fact]
        public void WriteConfigurationShouldWriteConfigurationObjectToFile()
        {
            string filePath = "test-config-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".json";

            ProjectConfiguration configuration = GetTestConfiguration();
            ConfigurationService.WriteConfiguration(filePath, configuration);
            Assert.True(File.Exists(filePath));

            string configurationStringFromFile = File.ReadAllText(filePath);
            string configurationStringFromObject = JsonConvert.SerializeObject(configuration);
            Assert.Equal(configurationStringFromObject, configurationStringFromFile);

            File.Delete(filePath);
        }
    }
}