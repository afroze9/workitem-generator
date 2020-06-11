using System;
using System.Collections.Generic;

namespace WorkItemGenerator.Models
{
    public class WorkItemLink
    {
        public string LinkType { get; set; }
        public WorkItemModel LinkedWorkItem { get; set; }
    }
}