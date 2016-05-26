using System;
using System.Collections.Generic;

namespace AdvancedJobProcessor.Entities
{
    [Serializable]
    public class JobQueue: List<Job>
    {
        public string DisplayName = "";
        public string Description = "";
        public int LogLevel = 1;
        private List<ExitCode> ExitCodes = new List<ExitCode>();

        public void Run()
        {
            foreach(Job job in this)
            {
                ExitCodes.Add(job.Run());
            }
        }
    }
}
