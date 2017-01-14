using System;
using System.IO.Ports;
using System.Windows.Forms;
using AutomatskoSkolskoZvono.Code;
using Quartz;
using Quartz.Impl;

namespace AutomatskoSkolskoZvono
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pokreniButton_Click(object sender, EventArgs e)
        {
            //if (_myPort.IsOpen == false)
            //{
            //    try
            //    {
            //        InitSerial(toolStripTextBox1.Text);
            //        if (_myPort.IsOpen)
            //        {
            //            PokreniZaustavi();
            //            pokreniButton.Enabled = false;
            //            btnZaustavi.Enabled = true;
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message, @"Greska pri pokretanju serijske komunikacije!");
            //    }
            //}
            //else
            //{
            //    PokreniZaustavi();
            //    pokreniButton.Enabled = false;
            //    btnZaustavi.Enabled = true;
            //}
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            ////myPort.Close();
            //_sched.Standby();
            ////sched.Shutdown(true);

            //pokreniButton.Enabled = true;
            //btnZaustavi.Enabled = false;
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
            //toolStripTextBox1.Text = Properties.Settings.Default.Port;
            //InitSerial(toolStripTextBox1.Text);
            //normalanToolStripMenuItem.PerformClick();

            //if (_myPort.IsOpen)
            //{
            //    pokreniButton.PerformClick();
            //}
            //else
            //{
            //    btnZaustavi.Enabled = false;
            //}
            //BellJob.Port = _myPort;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Properties.Settings.Default.Port = toolStripTextBox1.Text;
            //Properties.Settings.Default.Save();

            //if (!_myPort.IsOpen) return;

            //_sched?.Shutdown();
            //_myPort.Close();
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
