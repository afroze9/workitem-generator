<a name='assembly'></a>
# WorkItemGenerator.Services

## Contents

- [AzureDevOpsService](#T-WorkItemGenerator-Services-AzureDevOpsService 'WorkItemGenerator.Services.AzureDevOpsService')
  - [#ctor(serverUrl,projectName,personalAccessToken)](#M-WorkItemGenerator-Services-AzureDevOpsService-#ctor-System-String,System-String,System-String- 'WorkItemGenerator.Services.AzureDevOpsService.#ctor(System.String,System.String,System.String)')
  - [#ctor(serverUri,projectName,personalAccessToken)](#M-WorkItemGenerator-Services-AzureDevOpsService-#ctor-System-Uri,System-String,System-String- 'WorkItemGenerator.Services.AzureDevOpsService.#ctor(System.Uri,System.String,System.String)')
  - [Connection](#P-WorkItemGenerator-Services-AzureDevOpsService-Connection 'WorkItemGenerator.Services.AzureDevOpsService.Connection')
  - [PersonalAccessToken](#P-WorkItemGenerator-Services-AzureDevOpsService-PersonalAccessToken 'WorkItemGenerator.Services.AzureDevOpsService.PersonalAccessToken')
  - [ProjectName](#P-WorkItemGenerator-Services-AzureDevOpsService-ProjectName 'WorkItemGenerator.Services.AzureDevOpsService.ProjectName')
  - [ServerUri](#P-WorkItemGenerator-Services-AzureDevOpsService-ServerUri 'WorkItemGenerator.Services.AzureDevOpsService.ServerUri')
  - [TeamClient](#P-WorkItemGenerator-Services-AzureDevOpsService-TeamClient 'WorkItemGenerator.Services.AzureDevOpsService.TeamClient')
  - [WitClient](#P-WorkItemGenerator-Services-AzureDevOpsService-WitClient 'WorkItemGenerator.Services.AzureDevOpsService.WitClient')
  - [WorkClient](#P-WorkItemGenerator-Services-AzureDevOpsService-WorkClient 'WorkItemGenerator.Services.AzureDevOpsService.WorkClient')
  - [CreateWorkItem(item)](#M-WorkItemGenerator-Services-AzureDevOpsService-CreateWorkItem-WorkItemGenerator-Models-WorkItemModel- 'WorkItemGenerator.Services.AzureDevOpsService.CreateWorkItem(WorkItemGenerator.Models.WorkItemModel)')
  - [GetTeamFieldValuesAsync(projectId,teamId)](#M-WorkItemGenerator-Services-AzureDevOpsService-GetTeamFieldValuesAsync-System-String,System-String- 'WorkItemGenerator.Services.AzureDevOpsService.GetTeamFieldValuesAsync(System.String,System.String)')
  - [GetTeamIterationsAsync(projectId,teamId)](#M-WorkItemGenerator-Services-AzureDevOpsService-GetTeamIterationsAsync-System-String,System-String- 'WorkItemGenerator.Services.AzureDevOpsService.GetTeamIterationsAsync(System.String,System.String)')
  - [GetTeamMemberCapacities(projectId,teamId,iterationId)](#M-WorkItemGenerator-Services-AzureDevOpsService-GetTeamMemberCapacities-System-String,System-String,System-Guid- 'WorkItemGenerator.Services.AzureDevOpsService.GetTeamMemberCapacities(System.String,System.String,System.Guid)')
  - [GetTeamsAsync(projectId)](#M-WorkItemGenerator-Services-AzureDevOpsService-GetTeamsAsync-System-String- 'WorkItemGenerator.Services.AzureDevOpsService.GetTeamsAsync(System.String)')
  - [Init()](#M-WorkItemGenerator-Services-AzureDevOpsService-Init 'WorkItemGenerator.Services.AzureDevOpsService.Init')
  - [LinkWorkItems(baseItemId,linkItemId,linkType)](#M-WorkItemGenerator-Services-AzureDevOpsService-LinkWorkItems-System-Int32,System-Int32,System-String- 'WorkItemGenerator.Services.AzureDevOpsService.LinkWorkItems(System.Int32,System.Int32,System.String)')
- [ConfigurationService](#T-WorkItemGenerator-Services-ConfigurationService 'WorkItemGenerator.Services.ConfigurationService')
  - [ReadConfiguration(configFilePath)](#M-WorkItemGenerator-Services-ConfigurationService-ReadConfiguration-System-String- 'WorkItemGenerator.Services.ConfigurationService.ReadConfiguration(System.String)')
  - [Validate(configuration)](#M-WorkItemGenerator-Services-ConfigurationService-Validate-WorkItemGenerator-Models-ProjectConfiguration- 'WorkItemGenerator.Services.ConfigurationService.Validate(WorkItemGenerator.Models.ProjectConfiguration)')
  - [WriteConfiguration(configFilePath,configuration)](#M-WorkItemGenerator-Services-ConfigurationService-WriteConfiguration-System-String,WorkItemGenerator-Models-ProjectConfiguration- 'WorkItemGenerator.Services.ConfigurationService.WriteConfiguration(System.String,WorkItemGenerator.Models.ProjectConfiguration)')
- [WorkItemModelExtensions](#T-WorkItemGenerator-Services-WorkItemModelExtensions 'WorkItemGenerator.Services.WorkItemModelExtensions')
  - [ToJsonPatchDocument(item)](#M-WorkItemGenerator-Services-WorkItemModelExtensions-ToJsonPatchDocument-WorkItemGenerator-Models-WorkItemModel- 'WorkItemGenerator.Services.WorkItemModelExtensions.ToJsonPatchDocument(WorkItemGenerator.Models.WorkItemModel)')

<a name='T-WorkItemGenerator-Services-AzureDevOpsService'></a>
## AzureDevOpsService `type`

##### Namespace

WorkItemGenerator.Services

##### Summary

AzureDevOpsService Class.
Contains methods for creating and linking work items

<a name='M-WorkItemGenerator-Services-AzureDevOpsService-#ctor-System-String,System-String,System-String-'></a>
### #ctor(serverUrl,projectName,personalAccessToken) `constructor`

##### Summary

Constructor for the service.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| serverUrl | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | URL for the collection |
| projectName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Project Name |
| personalAccessToken | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | PAT for connecting to the service |

<a name='M-WorkItemGenerator-Services-AzureDevOpsService-#ctor-System-Uri,System-String,System-String-'></a>
### #ctor(serverUri,projectName,personalAccessToken) `constructor`

##### Summary

Constructor for the service.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| serverUri | [System.Uri](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Uri 'System.Uri') | URI for the collection |
| projectName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Project Name |
| personalAccessToken | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | PAT for connecting to the service |

<a name='P-WorkItemGenerator-Services-AzureDevOpsService-Connection'></a>
### Connection `property`

<a name='P-WorkItemGenerator-Services-AzureDevOpsService-PersonalAccessToken'></a>
### PersonalAccessToken `property`

<a name='P-WorkItemGenerator-Services-AzureDevOpsService-ProjectName'></a>
### ProjectName `property`

<a name='P-WorkItemGenerator-Services-AzureDevOpsService-ServerUri'></a>
### ServerUri `property`

<a name='P-WorkItemGenerator-Services-AzureDevOpsService-TeamClient'></a>
### TeamClient `property`

<a name='P-WorkItemGenerator-Services-AzureDevOpsService-WitClient'></a>
### WitClient `property`

<a name='P-WorkItemGenerator-Services-AzureDevOpsService-WorkClient'></a>
### WorkClient `property`

<a name='M-WorkItemGenerator-Services-AzureDevOpsService-CreateWorkItem-WorkItemGenerator-Models-WorkItemModel-'></a>
### CreateWorkItem(item) `method`

##### Summary

Creates a work item on Azure DevOps

##### Returns

Created work item id

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [WorkItemGenerator.Models.WorkItemModel](#T-WorkItemGenerator-Models-WorkItemModel 'WorkItemGenerator.Models.WorkItemModel') | Work item to create |

<a name='M-WorkItemGenerator-Services-AzureDevOpsService-GetTeamFieldValuesAsync-System-String,System-String-'></a>
### GetTeamFieldValuesAsync(projectId,teamId) `method`

##### Summary

Gets default area for a team

##### Returns

Team default area

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| projectId | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Project ID |
| teamId | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Team ID |

<a name='M-WorkItemGenerator-Services-AzureDevOpsService-GetTeamIterationsAsync-System-String,System-String-'></a>
### GetTeamIterationsAsync(projectId,teamId) `method`

##### Summary

Gets Iterations for a team

##### Returns

List of team iterations

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| projectId | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Project ID |
| teamId | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Team ID |

<a name='M-WorkItemGenerator-Services-AzureDevOpsService-GetTeamMemberCapacities-System-String,System-String,System-Guid-'></a>
### GetTeamMemberCapacities(projectId,teamId,iterationId) `method`

##### Summary

Gets the team member capacity information for a team's iteration

##### Returns

List of team members and their capacities by activity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| projectId | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Project ID |
| teamId | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Team ID |
| iterationId | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | Iteration ID |

<a name='M-WorkItemGenerator-Services-AzureDevOpsService-GetTeamsAsync-System-String-'></a>
### GetTeamsAsync(projectId) `method`

##### Summary

Gets a list of teams in the project

##### Returns

List of teams

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| projectId | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Project ID |

<a name='M-WorkItemGenerator-Services-AzureDevOpsService-Init'></a>
### Init() `method`

##### Summary

Creates a connection and initializes the clients

##### Parameters

This method has no parameters.

<a name='M-WorkItemGenerator-Services-AzureDevOpsService-LinkWorkItems-System-Int32,System-Int32,System-String-'></a>
### LinkWorkItems(baseItemId,linkItemId,linkType) `method`

##### Summary

Creates a link between two work items

##### Returns

true if successfull

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| baseItemId | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The id of the work item to update |
| linkItemId | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The id of the work item to link |
| linkType | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The relation of the linked item to the base item |

<a name='T-WorkItemGenerator-Services-ConfigurationService'></a>
## ConfigurationService `type`

##### Namespace

WorkItemGenerator.Services

##### Summary



<a name='M-WorkItemGenerator-Services-ConfigurationService-ReadConfiguration-System-String-'></a>
### ReadConfiguration(configFilePath) `method`

##### Summary

Reads configuration from a file into memory.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| configFilePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Location of the config file. |

<a name='M-WorkItemGenerator-Services-ConfigurationService-Validate-WorkItemGenerator-Models-ProjectConfiguration-'></a>
### Validate(configuration) `method`

##### Summary

Validates configuration file structure.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| configuration | [WorkItemGenerator.Models.ProjectConfiguration](#T-WorkItemGenerator-Models-ProjectConfiguration 'WorkItemGenerator.Models.ProjectConfiguration') | Configuration instance. |

<a name='M-WorkItemGenerator-Services-ConfigurationService-WriteConfiguration-System-String,WorkItemGenerator-Models-ProjectConfiguration-'></a>
### WriteConfiguration(configFilePath,configuration) `method`

##### Summary

Writes configuration from memory into a file.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| configFilePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Location of the config file. |
| configuration | [WorkItemGenerator.Models.ProjectConfiguration](#T-WorkItemGenerator-Models-ProjectConfiguration 'WorkItemGenerator.Models.ProjectConfiguration') | Configuration to store. |

<a name='T-WorkItemGenerator-Services-WorkItemModelExtensions'></a>
## WorkItemModelExtensions `type`

##### Namespace

WorkItemGenerator.Services

##### Summary

Extension methods for WorkItemModel.

<a name='M-WorkItemGenerator-Services-WorkItemModelExtensions-ToJsonPatchDocument-WorkItemGenerator-Models-WorkItemModel-'></a>
### ToJsonPatchDocument(item) `method`

##### Summary

Converts a WorkItemModel to a JsonPatchDocument.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [WorkItemGenerator.Models.WorkItemModel](#T-WorkItemGenerator-Models-WorkItemModel 'WorkItemGenerator.Models.WorkItemModel') | The item to convert. |
