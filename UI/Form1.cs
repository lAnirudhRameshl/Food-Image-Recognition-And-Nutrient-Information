using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ip1
{
    public partial class Form1 : Form
    {
        public void wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            //Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                //Console.WriteLine("stop wait timer");
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        string tb;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 0;
            button_WOC2.ButtonColor = Color.Gray;
            button_WOC2.Enabled = false;


        }



        private void button_WOC1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            tb = ofd.FileName;
            if(!string.IsNullOrEmpty(tb))
            {
                round1.Text = "  " + ofd.FileName;
                button_WOC2.ButtonColor = Color.Red;
                button_WOC2.Enabled = true;

            }
            

        }

        private void round1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            string strCmdText;
            strCmdText = "/C app.py \"";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = strCmdText + tb + "\"";
            process.StartInfo = startInfo;
            process.Start();
            button_WOC2.Text = "loading";
            while (!process.HasExited)
            {
                if (button_WOC2.Text == "loading...")
                {
                    button_WOC2.Text = "loading";
                }
                button_WOC2.Text += ".";
                wait(500);

            }
            process.WaitForExit();
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();

        }
    }
}
