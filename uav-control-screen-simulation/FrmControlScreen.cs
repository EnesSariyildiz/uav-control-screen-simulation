using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uav_control_screen_simulation
{
    public partial class FrmControlScreen : Form
    {
        public FrmControlScreen()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmControlScreen_Load(object sender, EventArgs e)
        {

        }
        int count, engineCount, flightTimeCount;
        private void BtnEngineStart_Click(object sender, EventArgs e)
        {


            progressBar1.Maximum = 100;

            progressBar1.Minimum = 0;

            progressBar1.Value = 0;


            Timer timer = new Timer();

            timer.Interval = 100;


            timer.Tick += (s, ev) =>
            {

                progressBar1.Value++;


                if (progressBar1.Value == progressBar1.Maximum)
                {
                    timer.Stop();
                    LblEngineYüzde.Text = "%100";
                }
            };
            timer.Start();
            timer2.Start();

        }

        private void BtnEngineStop_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            DialogResult result = MessageBox.Show("Stop the engine?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                TxtEngineStop.Text = "Engine is stoped!";
                progressBar1.Value = 0;
            }
            else if (result == DialogResult.No)
            {

                TxtEngineStop.Text = "Engine is not stoped!";
            }


        }

        private void BtnFlight_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Take off beggins");
            timer3.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            engineCount++;
            TxtEngineLeft.Text = "%" + engineCount.ToString();
            TxtEngineRight.Text = "%" + engineCount.ToString();

            if (engineCount == 100)
            {
                timer2.Stop();
            }
        }
        int saniye, dakika, saat;
        private void timer3_Tick(object sender, EventArgs e)
        {
            
            flightTimeCount++;
            TxtFlightTime.Text = flightTimeCount.ToString();
        }
    }
}
