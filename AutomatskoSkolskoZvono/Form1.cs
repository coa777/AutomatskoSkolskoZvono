using System;
using System.IO.Ports;
using System.Windows.Forms;
using Quartz;
using Quartz.Impl;

namespace AutomatskoSkolskoZvono
{
    public partial class Form1 : Form
    {
        // construct a scheduler factory
        private readonly ISchedulerFactory _schedFact = new StdSchedulerFactory();
        private IScheduler _sched;

        private static SerialPort _myPort;

        public Form1()
        {
            InitializeComponent();
        }

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


        private void pokreniButton_Click(object sender, EventArgs e)
        {
            if (_myPort.IsOpen == false)
            {
                try
                {
                    InitSerial(toolStripTextBox1.Text);
                    if (_myPort.IsOpen)
                    {
                        PokreniZaustavi();
                        pokreniButton.Enabled = false;
                        btnZaustavi.Enabled = true;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, @"Greska pri pokretanju serijske komunikacije!");
                }
            }
            else
            {
                PokreniZaustavi();
                pokreniButton.Enabled = false;
                btnZaustavi.Enabled = true;
            }
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            //myPort.Close();
            _sched.Standby();
            //sched.Shutdown(true);

            pokreniButton.Enabled = true;
            btnZaustavi.Enabled = false;
        }

        private void PokreniZaustavi()
        {

            // get a scheduler
            _sched = _schedFact.GetScheduler();

            _sched.Start();



            // define the job and tie it to our HelloJob class
            var job = JobBuilder.Create<Zvono>()
                .WithIdentity("jobZvono", "group1")
                .Build();


            // Ulazak u skolu  0 55 7 ? * MON-FRI
            var ulazak = "0 " + Okreni(txtUlazak.Text) + " ? * MON-FRI";
            var triggerUlazak = TriggerBuilder.Create()
                .WithIdentity("Ulazak", "group1")
                .WithCronSchedule(ulazak)
                .Build();

            // Prvi cas pocetak
            var prviCasPocetak = "0 " + Okreni(txtPrviPocetak.Text) + " ? * MON-FRI";
            var triggerPrviCasPocetak = TriggerBuilder.Create()
                .WithIdentity("PrviCasPocetak", "group1")
                .WithCronSchedule(prviCasPocetak)
                .Build();

            // Prvi cas kraj
            var prviCasKraj = "0 " + Okreni(txtPrviKraj.Text) + " ? * MON-FRI";
            var triggerPrviCasKraj = TriggerBuilder.Create()
                .WithIdentity("PrviCasKraj", "group1")
                .WithCronSchedule(prviCasKraj)
                .Build();


            // Drugi cas pocetak
            var drugiCasPocetak = "0 " + Okreni(txtDrugiPocetak.Text) + " ? * MON-FRI";
            var triggerDrugiCasPocetak = TriggerBuilder.Create()
                .WithIdentity("DrugiCasPocetak", "group1")
                .WithCronSchedule(drugiCasPocetak)
                .Build();

            // Drugi cas kraj
            var drugiCasKraj = "0 " + Okreni(txtDrugiKraj.Text) + " ? * MON-FRI";
            var triggerDrugiCasKraj = TriggerBuilder.Create()
                .WithIdentity("DrugiCasKraj", "group1")
                .WithCronSchedule(drugiCasKraj)
                .Build();

            // Veliki odmor ulazak u skolu
            var velikiOdmor = "0 " + Okreni(txtVelikiOdmor.Text) + " ? * MON-FRI";
            var triggerVelikiOdmor = TriggerBuilder.Create()
                .WithIdentity("VelikiOdmor", "group1")
                .WithCronSchedule(velikiOdmor)
                .Build();

            // Treci cas pocetak
            var treciCasPocetak = "0 " + Okreni(txtTreciPocetak.Text) + " ? * MON-FRI";
            var triggerTreciCasPocetak = TriggerBuilder.Create()
                .WithIdentity("TreciCasPocetak", "group1")
                .WithCronSchedule(treciCasPocetak)
                .Build();

            // Treci cas kraj
            var treciCasKraj = "0 " + Okreni(txtTreciKraj.Text) + " ? * MON-FRI";
            var triggerTreciCasKraj = TriggerBuilder.Create()
                .WithIdentity("TreciCasKraj", "group1")
                .WithCronSchedule(treciCasKraj)
                .Build();


            // Cetvrti cas pocetak
            var cetvrtiCasPocetak = "0 " + Okreni(txtCetvrtiPocetak.Text) + " ? * MON-FRI";
            var triggerCetvrtiCasPocetak = TriggerBuilder.Create()
                .WithIdentity("CetvrtiCasPocetak", "group1")
                .WithCronSchedule(cetvrtiCasPocetak)
                .Build();

            // Cetvrti cas kraj
            var cetvrtiCasKraj = "0 " + Okreni(txtCetvrtiKraj.Text) + " ? * MON-FRI";
            var triggerCetvrtiCasKraj = TriggerBuilder.Create()
                .WithIdentity("CetvrtiCasKraj", "group1")
                .WithCronSchedule(cetvrtiCasKraj)
                .Build();

            // Peti cas pocetak
            var petiCasPocetak = "0 " + Okreni(txtPetiPocetak.Text) + " ? * MON-FRI";
            var triggerPetiCasPocetak = TriggerBuilder.Create()
                .WithIdentity("PetiCasPocetak", "group1")
                .WithCronSchedule(petiCasPocetak)
                .Build();

            // Peti cas kraj
            var petiCasKraj = "0 " + Okreni(txtPetiKraj.Text) + " ? * MON-FRI";
            var triggerPetiCasKraj = TriggerBuilder.Create()
                .WithIdentity("PetiCasKraj", "group1")
                .WithCronSchedule(petiCasKraj)
                .Build();


            // Sesti cas pocetak
            var sestiCasPocetak = "0 " + Okreni(txtSestiPocetak.Text) + " ? * MON-FRI";
            var triggerSestiCasPocetak = TriggerBuilder.Create()
                .WithIdentity("SestiCasPocetak", "group1")
                .WithCronSchedule(sestiCasPocetak)
                .Build();

            // Sesti cas kraj
            var sestiCasKraj = "0 " + Okreni(txtSestiKraj.Text) + " ? * MON-FRI";
            var triggerSestiCasKraj = TriggerBuilder.Create()
                .WithIdentity("SestiCasKraj", "group1")
                .WithCronSchedule(sestiCasKraj)
                .Build();

            //// Sedmi cas pocetak
            //string sedmiCasPocetak = "0 " + okreni(txtSedmiPocetak.Text) + " ? * MON-FRI";
            //ITrigger trigSedmiCasPocetak = TriggerBuilder.Create()
            //    .WithIdentity("SedmiCasPocetak", "group1")
            //    .WithCronSchedule(sedmiCasPocetak)
            //    .Build();

            //// Sedmi cas kraj
            //string sedmiCasKraj = "0 45 17 ? * MON-FRI";
            //ITrigger trigSedmiCasKraj = TriggerBuilder.Create()
            //    .WithIdentity("SedmiCasKraj", "group1")
            //    .WithCronSchedule(sedmiCasKraj)
            //    .Build();

            var set = new Quartz.Collection.HashSet<ITrigger>
                              { triggerUlazak,
                                triggerPrviCasPocetak,
                                triggerPrviCasKraj,
                                triggerDrugiCasPocetak,
                                triggerDrugiCasKraj,
                                triggerVelikiOdmor,
                                triggerTreciCasPocetak,
                                triggerTreciCasKraj,
                                triggerCetvrtiCasPocetak,
                                triggerCetvrtiCasKraj,
                                triggerPetiCasPocetak,
                                triggerPetiCasKraj,
                                triggerSestiCasPocetak,
                                triggerSestiCasKraj,
                                //trigSedmiCasPocetak,
                                //trigSedmiCasKraj,
                              };
            _sched.ScheduleJob(job, set, true);
        }

        private string Okreni(string k)
        {
            string[] niz = k.Split(':');
            string nov = niz[1] + " " + niz[0];
            return nov;
        }

        private void Blokiraj(bool p)
        {
            txtUlazak.Enabled = p;
            txtPrviPocetak.Enabled = p;
            txtPrviKraj.Enabled = p;
            txtDrugiPocetak.Enabled = p;
            txtDrugiKraj.Enabled = p;
            txtVelikiOdmor.Enabled = p;
            txtTreciPocetak.Enabled = p;
            txtTreciKraj.Enabled = p;
            txtCetvrtiPocetak.Enabled = p;
            txtCetvrtiKraj.Enabled = p;
            txtPetiPocetak.Enabled = p;
            txtPetiKraj.Enabled = p;
            txtSestiPocetak.Enabled = p;
            txtSestiKraj.Enabled = p;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = Properties.Settings.Default.Port;
            InitSerial(toolStripTextBox1.Text);
            normalanToolStripMenuItem.PerformClick();

            if (_myPort.IsOpen)
            {
                pokreniButton.PerformClick();
            }
            else
            {
                btnZaustavi.Enabled = false;
            }
            Zvono.Port = _myPort;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Port = toolStripTextBox1.Text;
            Properties.Settings.Default.Save();

            if (!_myPort.IsOpen) return;

            _sched?.Shutdown();
            _myPort.Close();
        }

        private void normalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blokiraj(false);
            lblCasovi.Text = @"Casovi 45 min";

            txtUlazak.Text = @"7:55";

            txtPrviPocetak.Text = @"8:00";
            txtPrviKraj.Text = @"8:45";

            txtDrugiPocetak.Text = @"8:50";
            txtDrugiKraj.Text = @"9:35";

            txtVelikiOdmor.Text = @"9:50";

            txtTreciPocetak.Text = @"9:55";
            txtTreciKraj.Text = @"10:40";

            txtCetvrtiPocetak.Text = @"10:50";
            txtCetvrtiKraj.Text = @"11:35";

            txtPetiPocetak.Text = @"11:40";
            txtPetiKraj.Text = @"12:25";

            txtSestiPocetak.Text = @"12:30";
            txtSestiKraj.Text = @"13:15";
        }

        private void skraceniCasoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blokiraj(false);
            lblCasovi.Text = @"Casovi 35 min";

            txtUlazak.Text = @"7:55";

            txtPrviPocetak.Text = @"8:00";
            txtPrviKraj.Text = @"8:35";

            txtDrugiPocetak.Text = @"8:40";
            txtDrugiKraj.Text = @"9:15";

            txtVelikiOdmor.Text = @"9:30";

            txtTreciPocetak.Text = @"9:35";
            txtTreciKraj.Text = @"10:10";

            txtCetvrtiPocetak.Text = @"10:20";
            txtCetvrtiKraj.Text = @"10:55";

            txtPetiPocetak.Text = @"11:00";
            txtPetiKraj.Text = @"11:35";

            txtSestiPocetak.Text = @"11:40";
            txtSestiKraj.Text = @"12:15";
        }

        private void casovi30MinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blokiraj(false);
            lblCasovi.Text = @"Casovi 30 min";

            txtUlazak.Text = @"7:55";

            txtPrviPocetak.Text = @"8:00";
            txtPrviKraj.Text = @"8:30";

            txtDrugiPocetak.Text = @"8:35";
            txtDrugiKraj.Text = @"9:05";

            txtVelikiOdmor.Text = @"9:20";

            txtTreciPocetak.Text = @"9:25";
            txtTreciKraj.Text = @"9:55";

            txtCetvrtiPocetak.Text = @"10:05";
            txtCetvrtiKraj.Text = @"10:35";

            txtPetiPocetak.Text = @"10:40";
            txtPetiKraj.Text = @"11:10";

            txtSestiPocetak.Text = @"11:15";
            txtSestiKraj.Text = @"11:45";
        }

        private void manuelniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blokiraj(true);
            lblCasovi.Text = @"Manuelni raspored";
        }

        private void napustiProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
