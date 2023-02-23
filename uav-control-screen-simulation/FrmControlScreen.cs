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
            
        }

        private void BtnEngineStop_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Stop the engine?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                
                TxtEngineStop.Text = "Engine is stoped!";
            }
            else if (result == DialogResult.No)
            {
                
                TxtEngineStop.Text = "Engine is not stoped!";
            }

            
        }
    }
}
