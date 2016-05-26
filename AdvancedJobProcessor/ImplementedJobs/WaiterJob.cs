using System.Diagnostics;


namespace AdvancedJobProcessor.ImplementedJobs
{
    public class WaiterJob: Entities.Job
    {
        private string BASE_PATH = "";
        private string EXECUTABLE = "Waiter.exe";

        public WaiterJob(): base()
        {
            this.DisplayName = this.GetType().Name;
        }

        public override Entities.ExitCode Run()
        {
            var process = Process.Start(this.BASE_PATH + this.EXECUTABLE, this.GetParameterString());
            process.WaitForExit();
            var exitcode = new Entities.ExitCode();
            exitcode.Value = process.ExitCode;
            return exitcode;
        }
    }
}
