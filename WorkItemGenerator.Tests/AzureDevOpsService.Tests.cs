using System;
using System.Collections.Generic;
using Xunit;
using WorkItemGenerator.Models;
using WorkItemGenerator.Services;

namespace WorkItemGenerator.Tests
{
    public class AzureDevOpsServiceTests
    {
        private static readonly string WorkingServerUrl = @"https://dev.azure.com/afroze-tutorials/";
        private static readonly Uri WorkingServerUri = new Uri(WorkingServerUrl);
        private static readonly string WorkingProjectName = "Work Item Generation";
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
            int id = service.CreateWorkItem(MeetingWithoutLinks);
            Assert.NotEqual(-1, id);
        }
    }
}