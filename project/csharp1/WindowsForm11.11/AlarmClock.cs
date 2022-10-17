using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm11._11
{
    public partial class AlarmClock : Form
    {
        public static string alarmTime;
        public AlarmClock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 每隔一秒把当前的时间赋给label1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
            if (DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() == alarmTime)
            {
                SoundPlayer music = new SoundPlayer();
                music.SoundLocation = @"C:\Users\14345\Desktop\花に亡霊.wav";
                music.Play();
            }
        }

        /// <summary>
        /// 加载窗体时渐变出现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerOpacity_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.2;
        }

        /// <summary>
        /// 点击保存闹钟时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("："))
            {
                MessageBox.Show("输入错误请重新输入！");
                textBox1.Clear();
                textBox1.Focus();
            }
            else
            {
                alarmTime = textBox1.Text + ":0";
                MessageBox.Show("设置成功！");
            }
        }
    }

}
