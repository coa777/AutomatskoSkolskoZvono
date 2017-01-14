using System.IO.Ports;
using Quartz;

namespace AutomatskoSkolskoZvono
{
    public class Zvono : IJob
    {
        public static SerialPort Port { private get; set; }

        public void Execute(IJobExecutionContext context)
        {
            Port.WriteLine("1");
            //MessageBox.Show(context.FireTimeUtc.ToString());
        }
    }
}