using System;
using System.Collections.Generic;

namespace WorkItemGenerator.Models
{
    public class WorkItemModel
    {
        public string WorkItemType { get; set; }
        public Dictionary<string, object> FieldValues { get; set; }
        public List<WorkItemLink> Links { get; set; }
    }
}