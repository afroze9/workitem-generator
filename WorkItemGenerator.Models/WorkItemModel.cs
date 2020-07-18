using System;
using System.Collections.Generic;

namespace WorkItemGenerator.Models
{
    /// <summary>
    /// Model used to create items.
    /// </summary>
    public class WorkItemModel
    {
        /// <value>Type of workitem.</value>
        public string WorkItemType { get; set; }

        /// <value>Dictionary of fields and their values.</value>
        public Dictionary<string, object> FieldValues { get; set; }

        /// <value>Work items to link.</value>
        public List<WorkItemLink> Links { get; set; }

        /// <value>Whether or not the work item be created for each team member.</value>
        public bool CreateForEachMember { get; set; }
    }
}