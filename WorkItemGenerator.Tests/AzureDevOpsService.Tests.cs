using System;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.TeamFoundation.Work.WebApi;
using System.Collections.Generic;
using Xunit;
using WorkItemGenerator.Models;
using WorkItemGenerator.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WorkItemGenerator.Tests
{
    /// <summary>
    /// Contains tests for verifying AzureDevOps service implementation
    /// </summary>
    public class AzureDevOpsServiceTests
    {
        private static IConfiguration Configuration { get; set; }
        private static string WorkingServerUrl { get; set; }
        private static Uri WorkingServerUri { get => string.IsNullOrEmpty(WorkingServerUrl) ? null : new Uri(WorkingServerUrl); }
        private static string WorkingProjectName { get; set; }
        private static string WorkingProjectId { get; set; }
        private static string WorkingTeamId { get; set; }
        private static string WorkingTeamIterationId { get; set; }
        private static string WorkingPersonalAccessToken { get; set; }
        private static readonly WorkItemModel MeetingWithoutLinks = new WorkItemModel()
        {
            FieldValues = new Dictionary<string, object>()
            {
                {"System.Title", "Test Meeting"},
                {"System.Description", "Test Meeting Description"},
            },
            Links = null,
            WorkItemType = WorkItemType.Meeting
        };

        /// <summary>
        /// Initializes tests with values from appsettings.json.
        /// </summary>
        public AzureDevOpsServiceTests()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            WorkingServerUrl = Configuration.GetSection("WorkingServerUrl").Value;
            WorkingProjectName = Configuration.GetSection("WorkingProjectName").Value;
            WorkingProjectId = Configuration.GetSection("WorkingProjectId").Value;
            WorkingTeamId = Configuration.GetSection("WorkingTeamId").Value;
            WorkingTeamIterationId = Configuration.GetSection("WorkingTeamIterationId").Value;
            WorkingPersonalAccessToken = Configuration.GetSection("WorkingPersonalAccessToken").Value;

        }

        /// <summary>
        /// Checks if the provided configuration is valid (url in string format).
        /// </summary>
        [Fact]
        public void ConstructorWithStringShouldConnectToServer()
        {
            AzureDevOpsService service = new AzureDevOpsService(WorkingServerUrl, WorkingProjectName, WorkingPersonalAccessToken);
            Assert.NotNull(service.ServerUri);
            Assert.NotNull(service.ProjectName);
            Assert.NotNull(service.Connection);
            Assert.NotNull(service.WitClient);
        }

        /// <summary>
        /// Checks if the provided configuration is valid (url in uri format).
        /// </summary>
        [Fact]
        public void ConstructorWithUriShouldConnectToServer()
        {
            AzureDevOpsService service = new AzureDevOpsService(WorkingServerUri, WorkingProjectName, WorkingPersonalAccessToken);
            Assert.NotNull(service.ServerUri);
            Assert.NotNull(service.ProjectName);
            Assert.NotNull(service.Connection);
            Assert.NotNull(service.WitClient);
        }

        /// <summary>
        /// Creates and verifies a work item of type "Meeting".
        /// </summary>
        [Fact]
        public void CreateWorkItemShouldCreateMeetingWithoutLinks()
        {
            AzureDevOpsService service = new AzureDevOpsService(WorkingServerUri, WorkingProjectName, WorkingPersonalAccessToken);
            Task<int> creationTask = service.CreateWorkItem(MeetingWithoutLinks);
            creationTask.Wait();

            Assert.NotEqual(-1, creationTask.Result);
        }

        /// <summary>
        /// Creates and verifies a parent-child link between two work items.
        /// </summary>
        [Fact]
        public void LinkWorkItemsShouldLinkTwoWorkItemsAsParentChild()
        {
            int baseItemId = 3;
            int linkItemId = 4;

            AzureDevOpsService service = new AzureDevOpsService(WorkingServerUri, WorkingProjectName, WorkingPersonalAccessToken);
            Task<bool> linkingTask = service.LinkWorkItems(baseItemId, linkItemId, LinkType.Child);
            linkingTask.Wait();

            Assert.True(linkingTask.Result);
        }

        /// <summary>
        /// Verfies that the service returns teams.
        /// </summary>
        [Fact]
        public void GetTeamsShouldReturnTeams()
        {
            AzureDevOpsService service = new AzureDevOpsService(WorkingServerUri, WorkingProjectName, WorkingPersonalAccessToken);
            Task<List<WebApiTeam>> teamsTask = service.GetTeamsAsync(WorkingProjectId);
            teamsTask.Wait();

            Assert.True(teamsTask.IsCompletedSuccessfully);

            List<WebApiTeam> teams = teamsTask.Result;
            Assert.NotNull(teams);
        }

        /// <summary>
        /// Verfies that the service returns team field values.
        /// </summary>
        [Fact]
        public void GetTeamValuesShouldReturnFields()
        {
            AzureDevOpsService service = new AzureDevOpsService(WorkingServerUri, WorkingProjectName, WorkingPersonalAccessToken);
            Task<TeamFieldValues> fieldValuesTask = service.GetTeamFieldValuesAsync(WorkingProjectId, WorkingTeamId);
            fieldValuesTask.Wait();

            Assert.True(fieldValuesTask.IsCompletedSuccessfully);

            TeamFieldValues fieldValues = fieldValuesTask.Result;
            Assert.NotNull(fieldValues);
        }

        /// <summary>
        /// Verfies that the service returns team iterations.
        /// </summary>
        [Fact]
        public void GetTeamIterationsShouldReturnIterations()
        {
            AzureDevOpsService service = new AzureDevOpsService(WorkingServerUri, WorkingProjectName, WorkingPersonalAccessToken);
            Task<List<TeamSettingsIteration>> teamIterationsTask = service.GetTeamIterationsAsync(WorkingProjectId, WorkingTeamId);
            teamIterationsTask.Wait();

            Assert.True(teamIterationsTask.IsCompletedSuccessfully);

            List<TeamSettingsIteration> iterations = teamIterationsTask.Result;
            Assert.NotNull(iterations);
        }

        /// <summary>
        /// Verfies that the service returns team capactity.
        /// </summary>
        [Fact]
        public void GetTeamMemberCapacitiesShouldReturnCapacity()
        {
            AzureDevOpsService service = new AzureDevOpsService(WorkingServerUri, WorkingProjectName, WorkingPersonalAccessToken);
            Task<List<TeamMemberCapacityIdentityRef>> teamCapacityTask = service.GetTeamMemberCapacities(WorkingProjectId, WorkingTeamId, new Guid(WorkingTeamIterationId));
            teamCapacityTask.Wait();

            Assert.True(teamCapacityTask.IsCompletedSuccessfully);

            List<TeamMemberCapacityIdentityRef> capacities = teamCapacityTask.Result;
            Assert.NotNull(capacities);
        }
    }
}