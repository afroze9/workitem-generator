using System;
using System.Collections.Generic;

namespace WorkItemGenerator.Models
{
    public class TeamConfiguration
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string DefaultAreaPath { get; set; }
        public List<Iteration> IterationsToIgnore { get; set; }
        public List<Iteration> IterationsProcessed { get; set; }
        public List<WorkItem> WorkItems { get; set; }
    }
}