<a name='assembly'></a>
# WorkItemGenerator.Tests

## Contents

- [AzureDevOpsServiceTests](#T-WorkItemGenerator-Tests-AzureDevOpsServiceTests 'WorkItemGenerator.Tests.AzureDevOpsServiceTests')
  - [#ctor()](#M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-#ctor 'WorkItemGenerator.Tests.AzureDevOpsServiceTests.#ctor')
  - [ConstructorWithStringShouldConnectToServer()](#M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-ConstructorWithStringShouldConnectToServer 'WorkItemGenerator.Tests.AzureDevOpsServiceTests.ConstructorWithStringShouldConnectToServer')
  - [ConstructorWithUriShouldConnectToServer()](#M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-ConstructorWithUriShouldConnectToServer 'WorkItemGenerator.Tests.AzureDevOpsServiceTests.ConstructorWithUriShouldConnectToServer')
  - [CreateWorkItemShouldCreateMeetingWithoutLinks()](#M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-CreateWorkItemShouldCreateMeetingWithoutLinks 'WorkItemGenerator.Tests.AzureDevOpsServiceTests.CreateWorkItemShouldCreateMeetingWithoutLinks')
  - [GetTeamIterationsShouldReturnIterations()](#M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-GetTeamIterationsShouldReturnIterations 'WorkItemGenerator.Tests.AzureDevOpsServiceTests.GetTeamIterationsShouldReturnIterations')
  - [GetTeamMemberCapacitiesShouldReturnCapacity()](#M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-GetTeamMemberCapacitiesShouldReturnCapacity 'WorkItemGenerator.Tests.AzureDevOpsServiceTests.GetTeamMemberCapacitiesShouldReturnCapacity')
  - [GetTeamValuesShouldReturnFields()](#M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-GetTeamValuesShouldReturnFields 'WorkItemGenerator.Tests.AzureDevOpsServiceTests.GetTeamValuesShouldReturnFields')
  - [GetTeamsShouldReturnTeams()](#M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-GetTeamsShouldReturnTeams 'WorkItemGenerator.Tests.AzureDevOpsServiceTests.GetTeamsShouldReturnTeams')
  - [LinkWorkItemsShouldLinkTwoWorkItemsAsParentChild()](#M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-LinkWorkItemsShouldLinkTwoWorkItemsAsParentChild 'WorkItemGenerator.Tests.AzureDevOpsServiceTests.LinkWorkItemsShouldLinkTwoWorkItemsAsParentChild')

<a name='T-WorkItemGenerator-Tests-AzureDevOpsServiceTests'></a>
## AzureDevOpsServiceTests `type`

##### Namespace

WorkItemGenerator.Tests

##### Summary

Contains tests for verifying AzureDevOps service implementation

<a name='M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes tests with values from appsettings.json.

##### Parameters

This constructor has no parameters.

<a name='M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-ConstructorWithStringShouldConnectToServer'></a>
### ConstructorWithStringShouldConnectToServer() `method`

##### Summary

Checks if the provided configuration is valid (url in string format).

##### Parameters

This method has no parameters.

<a name='M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-ConstructorWithUriShouldConnectToServer'></a>
### ConstructorWithUriShouldConnectToServer() `method`

##### Summary

Checks if the provided configuration is valid (url in uri format).

##### Parameters

This method has no parameters.

<a name='M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-CreateWorkItemShouldCreateMeetingWithoutLinks'></a>
### CreateWorkItemShouldCreateMeetingWithoutLinks() `method`

##### Summary

Creates and verifies a work item of type "Meeting".

##### Parameters

This method has no parameters.

<a name='M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-GetTeamIterationsShouldReturnIterations'></a>
### GetTeamIterationsShouldReturnIterations() `method`

##### Summary

Verfies that the service returns team iterations.

##### Parameters

This method has no parameters.

<a name='M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-GetTeamMemberCapacitiesShouldReturnCapacity'></a>
### GetTeamMemberCapacitiesShouldReturnCapacity() `method`

##### Summary

Verfies that the service returns team capactity.

##### Parameters

This method has no parameters.

<a name='M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-GetTeamValuesShouldReturnFields'></a>
### GetTeamValuesShouldReturnFields() `method`

##### Summary

Verfies that the service returns team field values.

##### Parameters

This method has no parameters.

<a name='M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-GetTeamsShouldReturnTeams'></a>
### GetTeamsShouldReturnTeams() `method`

##### Summary

Verfies that the service returns teams.

##### Parameters

This method has no parameters.

<a name='M-WorkItemGenerator-Tests-AzureDevOpsServiceTests-LinkWorkItemsShouldLinkTwoWorkItemsAsParentChild'></a>
### LinkWorkItemsShouldLinkTwoWorkItemsAsParentChild() `method`

##### Summary

Creates and verifies a parent-child link between two work items.

##### Parameters

This method has no parameters.
