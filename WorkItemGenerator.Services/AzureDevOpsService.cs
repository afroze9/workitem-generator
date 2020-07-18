using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.TeamFoundation.Core.WebApi.Types;
using Microsoft.TeamFoundation.Work.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

        /// <value>Work Item Tracking Client used to work with work items</value>
        public WorkItemTrackingHttpClient WitClient { get; private set; }

        /// <value>Work Item Tracking Client used to work with work management</value>
        public WorkHttpClient WorkClient { get; private set; }

        /// <value>Team client used to work with team fields</value>
        public TeamHttpClient TeamClient { get; private set; }

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
        /// <param name="serverUri">URI for the collection</param>
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
            TeamClient = Connection.GetClient<TeamHttpClient>();
            WorkClient = Connection.GetClient<WorkHttpClient>();
        }


        /// <summary>
        /// Creates a work item on Azure DevOps
        /// </summary>
        /// <param name="item">Work item to create</param>
        /// <returns>Created work item id</returns>
        public async Task<int> CreateWorkItem(WorkItemModel item)
        {
            JsonPatchDocument document = item.ToJsonPatchDocument();
            WorkItem createdItem = await WitClient.CreateWorkItemAsync(document, ProjectName, item.WorkItemType);
            return createdItem.Id.Value;
        }

        /// <summary>
        /// Creates a link between two work items
        /// </summary>
        /// <param name="baseItemId">The id of the work item to update</param>
        /// <param name="linkItemId">The id of the work item to link</param>
        /// <param name="linkType">The relation of the linked item to the base item</param>
        /// <returns>true if successfull</returns>
        public async Task<bool> LinkWorkItems(int baseItemId, int linkItemId, string linkType)
        {
            string endpoint = $"{WitClient.BaseAddress}_apis/wit/workitems/{linkItemId}";

            JObject linkObject = JObject.FromObject(new
            {
                rel = linkType,
                url = endpoint
            });

            JsonPatchDocument document = new JsonPatchDocument()
            {
                new JsonPatchOperation()
                {
                    From = null,
                    Operation = Operation.Add,
                    Path = "/relations/-",
                    Value = linkObject
                }
            };

            await WitClient.UpdateWorkItemAsync(document, baseItemId);
            return true;
        }


        /// <summary>
        /// Gets a list of teams in the project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <returns>List of teams</returns>
        public async Task<List<WebApiTeam>> GetTeamsAsync(string projectId)
        {
            return await TeamClient.GetTeamsAsync(projectId);
        }


        /// <summary>
        /// Gets default area for a team
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="teamId">Team ID</param>
        /// <returns>Team default area</returns>
        public async Task<TeamFieldValues> GetTeamFieldValuesAsync(string projectId, string teamId)
        {
            TeamContext context = new TeamContext(projectId, teamId);
            return await WorkClient.GetTeamFieldValuesAsync(context);
        }


        /// <summary>
        /// Gets Iterations for a team
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="teamId">Team ID</param>
        /// <returns>List of team iterations</returns>
        public async Task<List<TeamSettingsIteration>> GetTeamIterationsAsync(string projectId, string teamId)
        {
            TeamContext context = new TeamContext(projectId, teamId);
            return await WorkClient.GetTeamIterationsAsync(context);
        }


        /// <summary>
        /// Gets the team member capacity information for a team's iteration
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="teamId">Team ID</param>
        /// <param name="iterationId">Iteration ID</param>
        /// <returns>List of team members and their capacities by activity</returns>
        public async Task<List<TeamMemberCapacityIdentityRef>> GetTeamMemberCapacities(string projectId, string teamId, Guid iterationId)
        {
            TeamContext context = new TeamContext(projectId, teamId);
            return await WorkClient.GetCapacitiesWithIdentityRefAsync(context, iterationId);
        }
    }
}
