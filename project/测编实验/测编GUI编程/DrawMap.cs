using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace 测编GUI编程
{
    public partial class DrawMap : Form
    {
        Color _col;

        public Color Col { get => _col; set => _col = value; }

        public void Draw(double X1, double Y1, double X2, double Y2)
        {
            Graphics paint = this.CreateGraphics();
            Pen pen = new Pen(Col);
            Point point1 = new Point((int)Math.Floor(X1), (int)Math.Floor(Y1));
            Point point2 = new Point((int)Math.Floor(X2), (int)Math.Floor(Y2));
            paint.DrawLine(pen, point1, point2);
            paint.Dispose();
        }
        public void FillTriangle(double X1, double Y1, double X2, double Y2, double X3, double Y3)
        {
            Graphics paint = this.CreateGraphics();
            Point point1 = new Point((int)Math.Floor(X1), (int)Math.Floor(Y1));
            Point point2 = new Point((int)Math.Floor(X2), (int)Math.Floor(Y2));
            Point point3 = new Point((int)Math.Floor(X3), (int)Math.Floor(Y3));
            Brush brush = new SolidBrush(Color.Red);
            brush = new LinearGradientBrush(point1, point2, Color.Red, Color.Purple);
            paint.FillPolygon(brush, new Point[] { point1, point2, point3 });
        }


        public DrawMap(Color colorValue)
        {
            InitializeComponent();
            this.Col = colorValue;
        }

        private string filename = null;
        private bool isSaved = false;
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "图片文件|*.jpeg|所有文件|*.*";
            sfd.RestoreDirectory = true;
            DialogResult result = sfd.ShowDialog();
            if (result == DialogResult.OK && isSaved == false)
            {
                filename = sfd.FileName;
                timer1.Enabled = true;
                timer1.Tick += new System.EventHandler(timer1_Tick);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (isSaved == false)
                {
                    Bitmap bit = new Bitmap(1920, 1080 - 65);
                    Graphics graphics = Graphics.FromImage(bit);
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.CopyFromScreen(0, 65, 0, 65, new Size(1920, 1080 - 65));
                    bit.Save(filename);
                    if (File.Exists(filename.ToString()))
                    {
                        MessageBox.Show("保存成功！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        isSaved = true;
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("保存失败！", "错误", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

    }
}



