using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using System;
using System.Threading.Tasks;
using WorkItemGenerator.Models;

namespace WorkItemGenerator.Services
{
    /// <summary>
    /// AzureDevOpsService Class.
    /// Contains methods for creating and linking work items
    /// </summary>
    public class AzureDevOpsService
    {
        /// <value>The Personal Access Token used to connect to Azure DevOps</value>
        private string PersonalAccessToken { get; set; }

        /// <value>Azure DevOps Collection Uri</value>
        public Uri ServerUri { get; private set; }

        /// <value>Azure DevOps Project Name</value>
        public string ProjectName { get; private set; }

        /// <value>Connection object used by the clients</value>
        public VssConnection Connection { get; private set; }

        /// <value>Work Item Track Client used to work with work items</value>
        public WorkItemTrackingHttpClient WitClient { get; private set; }

        /// <summary>
        /// Constructor for the service.
        /// </summary>
        /// <param name="serverUrl">URL for the collection</param>
        /// <param name="projectName">Project Name </param>
        /// <param name="personalAccessToken">PAT for connecting to the service</param>
        public AzureDevOpsService(string serverUrl, string projectName, string personalAccessToken)
        {
            ServerUri = new Uri(serverUrl);
            ProjectName = projectName;
            PersonalAccessToken = personalAccessToken;
            Init();
        }

        /// <summary>
        /// Constructor for the service.
        /// </summary>
        /// <param name="serverUrl">URI for the collection</param>
        /// <param name="projectName">Project Name </param>
        /// <param name="personalAccessToken">PAT for connecting to the service</param>
        public AzureDevOpsService(Uri serverUri, string projectName, string personalAccessToken)
        {
            ServerUri = serverUri;
            ProjectName = projectName;
            PersonalAccessToken = personalAccessToken;
            Init();
        }

        /// <summary>
        /// Creates a connection and initializes the clients
        /// </summary>
        private void Init()
        {
            VssBasicCredential credentials = new VssBasicCredential(string.Empty, PersonalAccessToken);
            Connection = new VssConnection(ServerUri, credentials);
            WitClient = Connection.GetClient<WorkItemTrackingHttpClient>();
        }


        /// <summary>
        /// Creates a work item on Azure DevOps
        /// </summary>
        /// <param name="item">Work item to create</param>
        /// <returns>Created work item id</returns>
        public int CreateWorkItem(WorkItemModel item)
        {
            JsonPatchDocument document = item.ToJsonPathDocument();
            Task<WorkItem> itemCreationTask = WitClient.CreateWorkItemAsync(document, ProjectName, item.WorkItemType);
            itemCreationTask.Wait();

            return itemCreationTask.Result.Id.Value;
        }
    }
}
