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
        int count, engineCount, fuelCount, rpmCount;
        private void BtnEngineStart_Click(object sender, EventArgs e)
        {
            TimerRPM.Start();
            TxtRpm.Text = rpmCount.ToString();

            timer4.Start();

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
            //progressBar1.Value = 0;

            DialogResult result = MessageBox.Show("Stop the engine?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                progressBar1.Value = 0;
                TxtEngineStop.Text = "Engine is stoped!";

            }
            else if (result == DialogResult.No)
            {

                TxtEngineStop.Text = "Engine is not stoped!";
            }


        }
        int flightTimeCount;
        private void BtnFlight_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("Take off beggins");
            flightTimeCount++;
            TxtFlightTime.Text = flightTimeCount.ToString();
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

        private void ChkWeather_CheckedChanged(object sender, EventArgs e)
        {

        }
        int speedPlusCount;
        private void BtnSpeedPlus_Click(object sender, EventArgs e)
        {

            speedPlusCount += 2;
            TxtSpeed.Text = speedPlusCount.ToString() + " " + "knot";
        }

        private void BtnSpeedMinus_Click(object sender, EventArgs e)
        {
            speedPlusCount -= 2;
            TxtSpeed.Text = speedPlusCount.ToString();
        }

        private void TxtFlightTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void TimerFlightTime_Tick(object sender, EventArgs e)
        {
            TimerFlightTime.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            fuelCount = 100;
            fuelCount--;
            if (fuelCount == 0)
            {
                timer4.Stop();
            }
            //fuelCount--;
            TxtFuel.Text = fuelCount.ToString();
        }


        int altitiudeCount, bankAngleCount;
        private void BtnAltitudePlus_Click(object sender, EventArgs e)
        {
            altitiudeCount += 5;
            TxtAltitude.Text = altitiudeCount.ToString() + " " + "ft";
            bankAngleCount += 5;
            if (bankAngleCount > 60)
            {
                bankAngleCount = 60;

            }
            TxtBankAngle.Text = bankAngleCount.ToString();
        }

        private void BtnCoordinatesConfirm_Click(object sender, EventArgs e)
        {
            TxtLatitude.Text = TxtXCoordinates.Text;
            TxtLongtude.Text = TxtYCoordinates.Text;
        }

        private void TimerRPM_Tick(object sender, EventArgs e)
        {
            TimerRPM.Start();

        }

        private void BtnAltitudeMinus_Click(object sender, EventArgs e)
        {
            altitiudeCount -= 5;
            TxtAltitude.Text = altitiudeCount.ToString();
            bankAngleCount -= 5;
            if (bankAngleCount < -40)
            {
                bankAngleCount = -40;

            }
            TxtBankAngle.Text = bankAngleCount.ToString() + " " + "ft";

        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (ChkFieldOfView.Checked && ChkRunway.Checked && ChkSafety.Checked && ChkWeather.Checked)
            {
                ChkWeather.ForeColor = Color.DarkSeaGreen;
                ChkSafety.ForeColor = Color.DarkSeaGreen;
                ChkRunway.ForeColor = Color.DarkSeaGreen;
                ChkFieldOfView.ForeColor = Color.DarkSeaGreen;
                MessageBox.Show("Security steps are complete !");
            }
            else
            {
                ChkWeather.ForeColor = Color.Red;
                ChkSafety.ForeColor = Color.Red;
                ChkRunway.ForeColor = Color.Red;
                ChkFieldOfView.ForeColor = Color.Red;
                MessageBox.Show("Please do the security steps !");
            }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            flightTimeCount++;
            TxtFlightTime.Text = flightTimeCount.ToString();
        }
    }
}
