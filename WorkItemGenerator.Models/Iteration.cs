using System;

namespace WorkItemGenerator.Models
{
    /// <summary>
    /// Iteration object used in configuration.
    /// </summary>
    public class Iteration
    {
        /// <value>GUID of the iteration.</value>
        public Guid IterationID { get; set; }

        /// <value>Iteration path.</value>
        public string IterationPath { get; set; }
    }
}