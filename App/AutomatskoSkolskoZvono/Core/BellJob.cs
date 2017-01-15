using System.IO.Ports;
using Quartz;

namespace AutomatskoSkolskoZvono.Core
{
    public class BellJob : IJob
    {
        public static SerialPort Port { private get; set; }

        public void Execute(IJobExecutionContext context)
        {
            Port.WriteLine("1");
        }
    }
}