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

        private void BtnEngineStart_Click(object sender, EventArgs e)
        {
            // ProgressBar'ın maximum değerini belirleyin
            progressBar1.Maximum = 100;

            // ProgressBar'ın minimum değerini belirleyin
            progressBar1.Minimum = 0;

            // ProgressBar'ı sıfırlayın
            progressBar1.Value = 0;

            // Timer'ı oluşturun ve Interval değerini ayarlayın
            Timer timer = new Timer();
            timer.Interval = 100;

            // Timer'ın Tick olayını ayarlayın
            timer.Tick += (s, ev) =>
            {
                // ProgressBar'ın değerini artırın
                progressBar1.Value++;

                // ProgressBar'ın maksimum değerine ulaştığında timer'ı durdurun
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    timer.Stop();
                    LblEngineYüzde.Text = "%100";
                }
            };

            // Timer'ı başlatın
            timer.Start();
            
        }

        private void BtnEngineStop_Click(object sender, EventArgs e)
        {
            TxtEngineStop.Text = "Engine is stoped!"; 
        }
    }
}
