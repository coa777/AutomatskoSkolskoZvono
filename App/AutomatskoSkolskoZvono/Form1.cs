using System;
using System.Windows.Forms;
using AutomatskoSkolskoZvono.Core;

namespace AutomatskoSkolskoZvono
{
    public partial class Form1 : Form
    {
        private readonly BellHandler _bellHandler;

        public Form1(BellHandler bellHandler)
        {
            _bellHandler = bellHandler;
            InitializeComponent();
        }

        private void pokreniButton_Click(object sender, EventArgs e)
        {
            var ringTimes = GetRingTimesFromScreen();
            _bellHandler.Start(CommunicationPortToolStripTextBox.Text, ringTimes);

            pokreniButton.Enabled = false;
            btnZaustavi.Enabled = true;
        }

        

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            _bellHandler.Pause();

            pokreniButton.Enabled = true;
            btnZaustavi.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CommunicationPortToolStripTextBox.Text = Properties.Settings.Default.Port;


            _bellHandler.InitSerial(CommunicationPortToolStripTextBox.Text);
            normalanToolStripMenuItem.PerformClick();

            if (_bellHandler.MyPort.IsOpen)
            {
                pokreniButton.PerformClick();
            }
            else
            {
                btnZaustavi.Enabled = false;
            }
            BellJob.Port = _bellHandler.MyPort;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Port = CommunicationPortToolStripTextBox.Text;
            Properties.Settings.Default.Save();

            _bellHandler.Stop();
        }

        private void normalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blokiraj(false);
            var ringTimes = _bellHandler.Get45MinRingTimes();

            SetRingTimes(ringTimes);
        }

        private void skraceniCasoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blokiraj(false);
            var ringTimes = _bellHandler.Get35MinRingTimes();

            SetRingTimes(ringTimes);
        }

        private void casovi30MinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blokiraj(false);
            var ringTimes = _bellHandler.Get30MinRingTimes();

            SetRingTimes(ringTimes);
        }

        private void manuelniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blokiraj(true);
            lblCasovi.Text = @"Manuelni raspored"; //TODO: Add write of custom schedule, xml vs json
        }

        private void napustiProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private RingTimes GetRingTimesFromScreen()
        {
            return new RingTimes
            {
                RingTimesSchedule = lblCasovi.Text,
                Entrance = txtUlazak.Text,
                FirstClassStart = txtPrviPocetak.Text,
                FirstClassEnd = txtPrviKraj.Text,
                SecondClassStart = txtDrugiPocetak.Text,
                SecondClassEnd = txtDrugiKraj.Text,
                LargeBreak = txtVelikiOdmor.Text,
                ThirdClassStart = txtTreciPocetak.Text,
                ThirdClassEnd = txtTreciKraj.Text,
                FourthClassStart = txtCetvrtiPocetak.Text,
                FourthClassEnd = txtCetvrtiKraj.Text,
                FifthClassStart = txtPetiPocetak.Text,
                FifthClassEnd = txtPetiKraj.Text,
                SixthClassStart = txtSestiPocetak.Text,
                SixthClassEnd = txtSestiKraj.Text
            };
        }

        private void SetRingTimes(RingTimes ringTimes)
        {
            lblCasovi.Text = ringTimes.RingTimesSchedule;
            txtUlazak.Text = ringTimes.Entrance;
            txtPrviPocetak.Text = ringTimes.FirstClassStart;
            txtPrviKraj.Text = ringTimes.FirstClassEnd;
            txtDrugiPocetak.Text = ringTimes.SecondClassStart;
            txtDrugiKraj.Text = ringTimes.SecondClassEnd;
            txtVelikiOdmor.Text = ringTimes.LargeBreak;
            txtTreciPocetak.Text = ringTimes.ThirdClassStart;
            txtTreciKraj.Text = ringTimes.ThirdClassEnd;
            txtCetvrtiPocetak.Text = ringTimes.FourthClassStart;
            txtCetvrtiKraj.Text = ringTimes.FourthClassEnd;
            txtPetiPocetak.Text = ringTimes.FifthClassStart;
            txtPetiKraj.Text = ringTimes.FifthClassEnd;
            txtSestiPocetak.Text = ringTimes.SixthClassStart;
            txtSestiKraj.Text = ringTimes.SixthClassEnd;
        }
    }
}
