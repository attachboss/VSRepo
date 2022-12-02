namespace 测编GUI编程
{
    partial class Azumith_Distance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Azumith_Distance));
            this.buttonAzumith = new System.Windows.Forms.Button();
            this.textBox_Bx = new System.Windows.Forms.TextBox();
            this.textBox_By = new System.Windows.Forms.TextBox();
            this.buttonDistance = new System.Windows.Forms.Button();
            this.groupBox_B = new System.Windows.Forms.GroupBox();
            this.groupBox_A = new System.Windows.Forms.GroupBox();
            this.textBox_Ax = new System.Windows.Forms.TextBox();
            this.textBox_Ay = new System.Windows.Forms.TextBox();
            this.textBoxAzumith = new System.Windows.Forms.TextBox();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.button_forwardCal = new System.Windows.Forms.Button();
            this.坐标正算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.坐标反算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox_B.SuspendLayout();
            this.groupBox_A.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAzumith
            // 
            this.buttonAzumith.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAzumith.Location = new System.Drawing.Point(532, 216);
            this.buttonAzumith.Name = "buttonAzumith";
            this.buttonAzumith.Size = new System.Drawing.Size(132, 35);
            this.buttonAzumith.TabIndex = 0;
            this.buttonAzumith.Text = "反算坐标方位角";
            this.buttonAzumith.UseVisualStyleBackColor = true;
            this.buttonAzumith.Click += new System.EventHandler(this.buttonAzumith_Click);
            // 
            // textBox_Bx
            // 
            this.textBox_Bx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_Bx.Location = new System.Drawing.Point(6, 24);
            this.textBox_Bx.Multiline = true;
            this.textBox_Bx.Name = "textBox_Bx";
            this.textBox_Bx.Size = new System.Drawing.Size(112, 42);
            this.textBox_Bx.TabIndex = 1;
            // 
            // textBox_By
            // 
            this.textBox_By.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_By.Location = new System.Drawing.Point(6, 72);
            this.textBox_By.Multiline = true;
            this.textBox_By.Name = "textBox_By";
            this.textBox_By.Size = new System.Drawing.Size(112, 46);
            this.textBox_By.TabIndex = 3;
            // 
            // buttonDistance
            // 
            this.buttonDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDistance.Location = new System.Drawing.Point(532, 267);
            this.buttonDistance.Name = "buttonDistance";
            this.buttonDistance.Size = new System.Drawing.Size(132, 35);
            this.buttonDistance.TabIndex = 2;
            this.buttonDistance.Text = "反算两点距离";
            this.buttonDistance.UseVisualStyleBackColor = true;
            this.buttonDistance.Click += new System.EventHandler(this.buttonDistance_Click);
            // 
            // groupBox_B
            // 
            this.groupBox_B.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox_B.Controls.Add(this.textBox_Bx);
            this.groupBox_B.Controls.Add(this.textBox_By);
            this.groupBox_B.Location = new System.Drawing.Point(409, 59);
            this.groupBox_B.Name = "groupBox_B";
            this.groupBox_B.Size = new System.Drawing.Size(124, 124);
            this.groupBox_B.TabIndex = 4;
            this.groupBox_B.TabStop = false;
            this.groupBox_B.Text = "B坐标";
            // 
            // groupBox_A
            // 
            this.groupBox_A.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox_A.Controls.Add(this.textBox_Ax);
            this.groupBox_A.Controls.Add(this.textBox_Ay);
            this.groupBox_A.Location = new System.Drawing.Point(251, 59);
            this.groupBox_A.Name = "groupBox_A";
            this.groupBox_A.Size = new System.Drawing.Size(124, 124);
            this.groupBox_A.TabIndex = 5;
            this.groupBox_A.TabStop = false;
            this.groupBox_A.Text = "A坐标";
            // 
            // textBox_Ax
            // 
            this.textBox_Ax.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_Ax.Location = new System.Drawing.Point(6, 24);
            this.textBox_Ax.Multiline = true;
            this.textBox_Ax.Name = "textBox_Ax";
            this.textBox_Ax.Size = new System.Drawing.Size(112, 42);
            this.textBox_Ax.TabIndex = 1;
            // 
            // textBox_Ay
            // 
            this.textBox_Ay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_Ay.Location = new System.Drawing.Point(6, 72);
            this.textBox_Ay.Multiline = true;
            this.textBox_Ay.Name = "textBox_Ay";
            this.textBox_Ay.Size = new System.Drawing.Size(112, 46);
            this.textBox_Ay.TabIndex = 3;
            // 
            // textBoxAzumith
            // 
            this.textBoxAzumith.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxAzumith.Location = new System.Drawing.Point(377, 216);
            this.textBoxAzumith.Multiline = true;
            this.textBoxAzumith.Name = "textBoxAzumith";
            this.textBoxAzumith.Size = new System.Drawing.Size(118, 35);
            this.textBoxAzumith.TabIndex = 6;
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDistance.Location = new System.Drawing.Point(377, 267);
            this.textBoxDistance.Multiline = true;
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(118, 33);
            this.textBoxDistance.TabIndex = 7;
            // 
            // button_forwardCal
            // 
            this.button_forwardCal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_forwardCal.Location = new System.Drawing.Point(577, 76);
            this.button_forwardCal.Name = "button_forwardCal";
            this.button_forwardCal.Size = new System.Drawing.Size(87, 35);
            this.button_forwardCal.TabIndex = 9;
            this.button_forwardCal.Text = "正算";
            this.button_forwardCal.UseVisualStyleBackColor = true;
            this.button_forwardCal.Click += new System.EventHandler(this.button_forwardCal_Click);
            // 
            // 坐标正算ToolStripMenuItem
            // 
            this.坐标正算ToolStripMenuItem.Name = "坐标正算ToolStripMenuItem";
            this.坐标正算ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.坐标正算ToolStripMenuItem.Text = "坐标正算";
            this.坐标正算ToolStripMenuItem.Click += new System.EventHandler(this.坐标正算ToolStripMenuItem_Click);
            // 
            // 坐标反算ToolStripMenuItem
            // 
            this.坐标反算ToolStripMenuItem.Name = "坐标反算ToolStripMenuItem";
            this.坐标反算ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.坐标反算ToolStripMenuItem.Text = "坐标反算";
            this.坐标反算ToolStripMenuItem.Click += new System.EventHandler(this.坐标反算ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.坐标正算ToolStripMenuItem,
            this.坐标反算ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(693, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "坐标方位角：";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "两点距离：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Location = new System.Drawing.Point(26, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 224);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Azumith_Distance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(693, 366);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_forwardCal);
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.textBoxAzumith);
            this.Controls.Add(this.groupBox_A);
            this.Controls.Add(this.groupBox_B);
            this.Controls.Add(this.buttonDistance);
            this.Controls.Add(this.buttonAzumith);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Azumith_Distance";
            this.Text = "坐标计算";
            this.Load += new System.EventHandler(this.Azumith_Distance_Load);
            this.groupBox_B.ResumeLayout(false);
            this.groupBox_B.PerformLayout();
            this.groupBox_A.ResumeLayout(false);
            this.groupBox_A.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAzumith;
        private System.Windows.Forms.TextBox textBox_Bx;
        private System.Windows.Forms.TextBox textBox_By;
        private System.Windows.Forms.Button buttonDistance;
        private System.Windows.Forms.GroupBox groupBox_B;
        private System.Windows.Forms.GroupBox groupBox_A;
        private System.Windows.Forms.TextBox textBox_Ax;
        private System.Windows.Forms.TextBox textBox_Ay;
        private System.Windows.Forms.TextBox textBoxAzumith;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.Button button_forwardCal;
        private System.Windows.Forms.ToolStripMenuItem 坐标正算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 坐标反算ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}