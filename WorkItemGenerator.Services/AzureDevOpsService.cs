using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;

namespace WorkItemGenerator.Services
{
    public class AzureDevOpsService
    {
        private string PersonalAccessToken { get; set; }
        public Uri ServerUri { get; private set; }
        public string ProjectName { get; private set; }
        public VssConnection Connection { get; private set; }
        public WorkItemTrackingHttpClient WitClient { get; private set; }

        public AzureDevOpsService(string serverUrl, string projectName, string personalAccessToken)
        {
            ServerUri = new Uri(serverUrl);
            ProjectName = projectName;
            PersonalAccessToken = personalAccessToken;
            Init();
        }

        public AzureDevOpsService(Uri serverUri, string projectName, string personalAccessToken)
        {
            ServerUri = serverUri;
            ProjectName = projectName;
            PersonalAccessToken = personalAccessToken;
            Init();
        }

        private void Init()
        {
            VssBasicCredential credentials = new VssBasicCredential(string.Empty, PersonalAccessToken);
            Connection = new VssConnection(ServerUri, credentials);
            WitClient = Connection.GetClient<WorkItemTrackingHttpClient>();
        }
    }
}
