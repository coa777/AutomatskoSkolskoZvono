using System;
using System.IO.Ports;
using System.Windows.Forms;
using AutomatskoSkolskoZvono.Core.ExtensionMethods;
using Quartz;
using Quartz.Impl;

namespace AutomatskoSkolskoZvono.Core
{
    public class BellHandler
    {
        // construct a scheduler factory
        private readonly ISchedulerFactory _schedFact = new StdSchedulerFactory();
        private IScheduler _sched;

        public SerialPort MyPort;

        public void InitSerial(string port)
        {
            MyPort = new SerialPort
            {
                BaudRate = 9600,
                PortName = port
            };

            try
            {
                MyPort.Open();
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

        public void Start(string port, RingTimes ringTimes)
        {
            if (MyPort.IsOpen == false)
            {
                try
                {
                    InitSerial(port);
                    if(MyPort.IsOpen)
                    {
                        PokreniZaustavi(ringTimes);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Greska pri pokretanju serijske komunikacije!");
                }
            }
            else
            {
                PokreniZaustavi(ringTimes);
            }
        }

        public void Pause()
        {
            _sched.Standby();
        }

        public void Stop()
        {
            if (!MyPort.IsOpen) return;

            _sched?.Shutdown();
            MyPort.Close();
        }

        public RingTimes Get45MinRingTimes()
        {
            return new RingTimes
            {
                RingTimesSchedule = @"Casovi 45 min",
                Entrance = @"7:55",
                FirstClassStart = @"8:00",
                FirstClassEnd = @"8:45",
                SecondClassStart = @"8:50",
                SecondClassEnd = @"9:35",
                LargeBreak = @"9:50",
                ThirdClassStart = @"9:55",
                ThirdClassEnd = @"10:40",
                FourthClassStart = @"10:50",
                FourthClassEnd = @"11:35",
                FifthClassStart = @"11:40",
                FifthClassEnd = @"12:25",
                SixthClassStart = @"12:30",
                SixthClassEnd = @"13:15"
            };
        }

        public RingTimes Get35MinRingTimes()
        {
            return new RingTimes
            {
                RingTimesSchedule = @"Casovi 35 min",
                Entrance = @"7:55",
                FirstClassStart = @"8:00",
                FirstClassEnd = @"8:35",
                SecondClassStart = @"8:40",
                SecondClassEnd = @"9:15",
                LargeBreak = @"9:30",
                ThirdClassStart = @"9:35",
                ThirdClassEnd = @"10:10",
                FourthClassStart = @"10:20",
                FourthClassEnd = @"10:55",
                FifthClassStart = @"11:00",
                FifthClassEnd = @"11:35",
                SixthClassStart = @"11:40",
                SixthClassEnd = @"12:15"
            };
        }

        public RingTimes Get30MinRingTimes()
        {
            return new RingTimes
            {
                RingTimesSchedule = @"Casovi 30 min",
                Entrance = @"7:55",
                FirstClassStart = @"8:00",
                FirstClassEnd = @"8:30",
                SecondClassStart = @"8:35",
                SecondClassEnd = @"9:05",
                LargeBreak = @"9:20",
                ThirdClassStart = @"9:25",
                ThirdClassEnd = @"9:55",
                FourthClassStart = @"10:05",
                FourthClassEnd = @"10:35",
                FifthClassStart = @"10:40",
                FifthClassEnd = @"11:10",
                SixthClassStart = @"11:15",
                SixthClassEnd = @"11:45"
            };
        }
    }
}
