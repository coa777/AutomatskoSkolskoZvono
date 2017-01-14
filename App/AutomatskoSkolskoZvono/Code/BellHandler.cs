using System;
using System.IO.Ports;
using System.Windows.Forms;
using AutomatskoSkolskoZvono.Code.ExtensionMethods;
using Quartz;
using Quartz.Impl;

namespace AutomatskoSkolskoZvono.Code
{
    public class BellHandler
    {
        // construct a scheduler factory
        private readonly ISchedulerFactory _schedFact = new StdSchedulerFactory();
        private IScheduler _sched;

        private static SerialPort _myPort;

        private void InitSerial(string k)
        {
            _myPort = new SerialPort
            {
                BaudRate = 9600,
                PortName = k
            };

            try
            {
                _myPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error");
                //throw;   
            }
        }

        private void PokreniZaustavi(RingTimes ringTimes)
        {

            // get a scheduler
            _sched = _schedFact.GetScheduler();

            _sched.Start();



            // define the job and tie it to our HelloJob class
            var job = JobBuilder.Create<BellJob>()
                .WithIdentity("jobZvono", "group1")
                .Build();


            var triggerEntrance = TriggerBuilder.Create()
                .WithIdentity("Entrance", "group1")
                .WithCronSchedule(ringTimes.Entrance.ToCronExpression())
                .Build();

            var triggerFirstClassStart = TriggerBuilder.Create()
                .WithIdentity("FirstClassStart", "group1")
                .WithCronSchedule(ringTimes.FirstClassStart.ToCronExpression())
                .Build();

            var triggerFirstClassEnd = TriggerBuilder.Create()
                .WithIdentity("FirstClassEnd", "group1")
                .WithCronSchedule(ringTimes.FirstClassEnd.ToCronExpression())
                .Build();


            var triggerSecondClassStart = TriggerBuilder.Create()
                .WithIdentity("SecondClassStart", "group1")
                .WithCronSchedule(ringTimes.SecondClassStart.ToCronExpression())
                .Build();

            var triggerSecondClassEnd = TriggerBuilder.Create()
                .WithIdentity("SecondClassEnd", "group1")
                .WithCronSchedule(ringTimes.SecondClassEnd.ToCronExpression())
                .Build();

            
            var triggerLargeBreak = TriggerBuilder.Create()
                .WithIdentity("LargeBreak", "group1")
                .WithCronSchedule(ringTimes.LargeBreak.ToCronExpression())
                .Build();

            
            var triggerThirdClassStart = TriggerBuilder.Create()
                .WithIdentity("ThirdClassStart", "group1")
                .WithCronSchedule(ringTimes.ThirdClassStart.ToCronExpression())
                .Build();

           var triggerThirdClassEnd = TriggerBuilder.Create()
                .WithIdentity("ThirdClassEnd", "group1")
                .WithCronSchedule(ringTimes.ThirdClassEnd.ToCronExpression())
                .Build();


            var triggerFourthClassStart = TriggerBuilder.Create()
                .WithIdentity("FourthClassStart", "group1")
                .WithCronSchedule(ringTimes.FourthClassStart.ToCronExpression())
                .Build();

            var triggerFourthClassEnd = TriggerBuilder.Create()
                .WithIdentity("FourthClassEnd", "group1")
                .WithCronSchedule(ringTimes.FourthClassEnd.ToCronExpression())
                .Build();

            
            var triggerFifthClassStart = TriggerBuilder.Create()
                .WithIdentity("FifthClassStart", "group1")
                .WithCronSchedule(ringTimes.FifthClassStart.ToCronExpression())
                .Build();

            var triggerFifthClassEnd = TriggerBuilder.Create()
                .WithIdentity("FifthClassEnd", "group1")
                .WithCronSchedule(ringTimes.FifthClassEnd.ToCronExpression())
                .Build();


            var triggerSixthClassStart = TriggerBuilder.Create()
                .WithIdentity("SixthClassStart", "group1")
                .WithCronSchedule(ringTimes.SixthClassStart.ToCronExpression())
                .Build();

           var triggerSixthClassEnd = TriggerBuilder.Create()
                .WithIdentity("SixthClassEnd", "group1")
                .WithCronSchedule(ringTimes.SixthClassEnd.ToCronExpression())
                .Build();

            var set = new Quartz.Collection.HashSet<ITrigger>
                              { triggerEntrance,
                                triggerFirstClassStart,
                                triggerFirstClassEnd,
                                triggerSecondClassStart,
                                triggerSecondClassEnd,
                                triggerLargeBreak,
                                triggerThirdClassStart,
                                triggerThirdClassEnd,
                                triggerFourthClassStart,
                                triggerFourthClassEnd,
                                triggerFifthClassStart,
                                triggerFifthClassEnd,
                                triggerSixthClassStart,
                                triggerSixthClassEnd
                              };

            _sched.ScheduleJob(job, set, true);
        }
    }
}
