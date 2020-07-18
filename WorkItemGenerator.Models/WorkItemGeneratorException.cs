using System;
using System.Runtime.Serialization;
namespace WorkItemGenerator.Models
{
    [Serializable]
    public class WorkItemGeneratorException : Exception
    {
        public WorkItemGeneratorException() { }
        public WorkItemGeneratorException(string message) : base(message) { }
        public WorkItemGeneratorException(string message, Exception inner) : base(message, inner) { }
        protected WorkItemGeneratorException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}