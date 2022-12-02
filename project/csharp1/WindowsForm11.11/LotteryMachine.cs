using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm11._11
{
    public partial class LotteryMachine : Form
    {
        public LotteryMachine()
        {
            InitializeComponent();
        }

        bool isRunning = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (isRunning == false)
            {
                isRunning = true;
                this.button1.Text = "暂停";
                Thread th = new Thread(Random);
                th.IsBackground = true;
                th.Start();
            }
            else
            {
                isRunning = false;
                this.button1.Text = "开始";
            }
        }

        private void Random()
        {
            Random r = new Random();
            while (isRunning)
            {
                this.label1.Text = r.Next(0, 1 + 9).ToString();
                this.label2.Text = r.Next(0, 1 + 9).ToString();
                this.label3.Text = r.Next(0, 1 + 9).ToString();
            }
        }

        private void LotteryMachine_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
