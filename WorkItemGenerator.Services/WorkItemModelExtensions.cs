using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using WorkItemGenerator.Models;

namespace WorkItemGenerator.Services
{
    /// <summary>
    /// Extension methods for WorkItemModel.
    /// </summary>
    public static class WorkItemModelExtensions
    {

        /// <summary>
        /// Converts a WorkItemModel to a JsonPatchDocument.
        /// </summary>
        /// <param name="item">The item to convert.</param>
        /// <returns></returns>
        public static JsonPatchDocument ToJsonPatchDocument(this WorkItemModel item)
        {
            JsonPatchDocument document = new JsonPatchDocument();

            if (item.FieldValues == null || item.FieldValues.Count == 0)
                throw new ArgumentNullException(nameof(item.FieldValues));

            if (!item.FieldValues.ContainsKey("System.Title") || item.FieldValues["System.Title"] == null)
                throw new ArgumentException("Must at least contain a value for System.Title", nameof(item.FieldValues));

            foreach (KeyValuePair<string, object> fieldValue in item.FieldValues)
            {
                JsonPatchOperation op = new JsonPatchOperation()
                {
                    From = null,
                    Operation = Operation.Add,
                    Path = $"/fields/{fieldValue.Key}",
                    Value = fieldValue.Value
                };
                document.Add(op);
            }

            return document;
        }
    }
}