using System;
using Xunit;
using WorkItemGenerator.Models;
using WorkItemGenerator.Services;

namespace WorkItemGenerator.Tests
{
    public class AzureDevOpsServiceTests
    {
        private static readonly string WorkingServerUrl = @"";
        private static readonly Uri WorkingServerUri = new Uri(WorkingServerUrl);
        private static readonly string WorkingProjectName = "Work Item Generation";
        private static readonly string WorkingPersonalAccessToken = "";

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
    }
}