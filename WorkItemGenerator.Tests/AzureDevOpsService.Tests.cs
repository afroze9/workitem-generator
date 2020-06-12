using System;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.TeamFoundation.Work.WebApi;
using System.Collections.Generic;
using Xunit;
using WorkItemGenerator.Models;
using WorkItemGenerator.Services;
using System.Threading.Tasks;

namespace WorkItemGenerator.Tests
{
    public class AzureDevOpsServiceTests
    {
        private static readonly string WorkingServerUrl = @"https://dev.azure.com/afroze-tutorials/";
        private static readonly Uri WorkingServerUri = new Uri(WorkingServerUrl);
        private static readonly string WorkingProjectName = "Work Item Generation";
        private static readonly string WorkingProjectId = "82bd5e17-d317-47a7-b4a1-6971d6b906b2";
        private static readonly string WorkingTeamId = "7adea90a-367d-438e-9651-93b96f3456a8";
        private static readonly string WorkingTeamIterationId = "957d1852-eff8-407e-bdd5-bb4c4a0d1fb8";
        private static readonly string WorkingPersonalAccessToken = "";
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

        [Fact]
        public void ConstructorWithStringShouldConnectToServer()
        {
            AzureDevOpsService service = new AzureDevOpsService(WorkingServerUrl, WorkingProjectName, WorkingPersonalAccessToken);
            Assert.NotNull(service.ServerUri);
            Assert.NotNull(service.ProjectName);
            Assert.NotNull(service.Connection);
            Assert.NotNull(service.WitClient);
        }

        [Fact]
        public void ConstructorWithUriShouldConnectToServer()
        {
            AzureDevOpsService service = new AzureDevOpsService(WorkingServerUri, WorkingProjectName, WorkingPersonalAccessToken);
            Assert.NotNull(service.ServerUri);
            Assert.NotNull(service.ProjectName);
            Assert.NotNull(service.Connection);
            Assert.NotNull(service.WitClient);
        }

        [Fact]
        public void CreateWorkItemShouldCreateMeetingWithoutLinks()
        {
            AzureDevOpsService service = new AzureDevOpsService(WorkingServerUri, WorkingProjectName, WorkingPersonalAccessToken);
            Task<int> creationTask = service.CreateWorkItem(MeetingWithoutLinks);
            creationTask.Wait();

            Assert.NotEqual(-1, creationTask.Result);
        }

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