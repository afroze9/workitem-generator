using System;
using System.Collections.Generic;
using Xunit;
using WorkItemGenerator.Models;
using WorkItemGenerator.Services;

namespace WorkItemGenerator.Tests
{
    public class AzureDevOpsServiceExtensionTests
    {
        private static readonly WorkItemModel ValidWorkItemModelWithoutLinks = new WorkItemModel()
        {
            FieldValues = new Dictionary<string, object>()
            {
                {"System.Title", "Test Title"},
                {"System.Description", "Test Description"}
            },
            Links = null,
            WorkItemType = WorkItemType.Meeting
        };

        private static readonly WorkItemModel InvalidWorkItemModelA = new WorkItemModel()
        {
            FieldValues = null,
            Links = null,
            WorkItemType = WorkItemType.Meeting
        };

        private static readonly WorkItemModel InvalidWorkItemModelB = new WorkItemModel()
        {
            FieldValues = new Dictionary<string, object>()
            {
                {"System.Description", "Test Description"}
            },
            Links = null,
            WorkItemType = WorkItemType.Meeting
        };

        [Fact]
        public void ToJsonPatchDocumentShouldSuccessfullyConvertWorkitemModel()
        {
            Assert.NotNull(ValidWorkItemModelWithoutLinks.ToJsonPatchDocument());
        }

        [Fact]
        public void ToJsonPatchDocumentShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => InvalidWorkItemModelA.ToJsonPatchDocument());
        }

        [Fact]
        public void ToJsonPatchDocumentShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => InvalidWorkItemModelB.ToJsonPatchDocument());
        }
    }
}