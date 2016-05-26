using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AdvancedJobProcessor.Entities
{
    [XmlInclude(typeof(ImplementedJobs.WaiterJob))]
    [Serializable]
    public class Job: IRunnableInterface
    {
        public string DisplayName = "";
        public Parameters Parameters = new Parameters();
        public List<ExitCode> ExitCodes = new List<ExitCode>();
        public List<ExitCode> ErrorCodes = new List<ExitCode>();

        public virtual ExitCode Run()
        {
            return new ExitCode();
        }

        public bool IsRunnable()
        {
            throw new NotImplementedException();
        }

        public string GetParameterString()
        {
            List<string> parameterString = new List<string>();
            foreach (var parameter in this.Parameters)
            {
                parameterString.Add(String.Join("", this.Parameters.Prefix, parameter.Name, this.Parameters.Delimiter, parameter.Value));
            }
            return String.Join(" ", parameterString);
        }
    }
}
