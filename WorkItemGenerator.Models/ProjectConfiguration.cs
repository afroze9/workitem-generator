using System;
using System.Collections.Generic;

namespace WorkItemGenerator.Models
{
    public class ProjectConfiguration
    {
        public Uri CollectionUri { get; set; }
        public string ProjectName { get; set; }
        public Guid ProjectId { get; set; }
        public List<TeamConfiguration> TeamConfigurations { get; set; }
    }
}
