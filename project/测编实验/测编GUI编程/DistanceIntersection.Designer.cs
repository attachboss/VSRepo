namespace 测编GUI编程
{
    partial class DistanceIntersection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistanceIntersection));
            this.textBox_Ax = new System.Windows.Forms.TextBox();
            this.textBox_AP = new System.Windows.Forms.TextBox();
            this.textBox_Ay = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Bx = new System.Windows.Forms.TextBox();
            this.textBox_By = new System.Windows.Forms.TextBox();
            this.textBox_BP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_Px = new System.Windows.Forms.TextBox();
            this.textBox_Py = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存为文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存到数据库ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.打开结果文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.保存到文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存到数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制交会图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Ax
            // 
            this.textBox_Ax.Location = new System.Drawing.Point(16, 24);
            this.textBox_Ax.Name = "textBox_Ax";
            this.textBox_Ax.Size = new System.Drawing.Size(100, 25);
            this.textBox_Ax.TabIndex = 0;
            // 
            // textBox_AP
            // 
            this.textBox_AP.Location = new System.Drawing.Point(532, 64);
            this.textBox_AP.Name = "textBox_AP";
            this.textBox_AP.Size = new System.Drawing.Size(100, 25);
            this.textBox_AP.TabIndex = 1;
            // 
            // textBox_Ay
            // 
            this.textBox_Ay.Location = new System.Drawing.Point(16, 67);
            this.textBox_Ay.Name = "textBox_Ay";
            this.textBox_Ay.Size = new System.Drawing.Size(100, 25);
            this.textBox_Ay.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Ax);
            this.groupBox1.Controls.Add(this.textBox_Ay);
            this.groupBox1.Location = new System.Drawing.Point(70, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 106);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入A点坐标";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Bx);
            this.groupBox2.Controls.Add(this.textBox_By);
            this.groupBox2.Location = new System.Drawing.Point(243, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 106);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输入B点坐标";
            // 
            // textBox_Bx
            // 
            this.textBox_Bx.Location = new System.Drawing.Point(16, 24);
            this.textBox_Bx.Name = "textBox_Bx";
            this.textBox_Bx.Size = new System.Drawing.Size(100, 25);
            this.textBox_Bx.TabIndex = 0;
            // 
            // textBox_By
            // 
            this.textBox_By.Location = new System.Drawing.Point(16, 67);
            this.textBox_By.Name = "textBox_By";
            this.textBox_By.Size = new System.Drawing.Size(100, 25);
            this.textBox_By.TabIndex = 2;
            // 
            // textBox_BP
            // 
            this.textBox_BP.Location = new System.Drawing.Point(532, 118);
            this.textBox_BP.Name = "textBox_BP";
            this.textBox_BP.Size = new System.Drawing.Size(100, 25);
            this.textBox_BP.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "输入AP边长(m)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "输入BP边长(m)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_Px);
            this.groupBox3.Controls.Add(this.textBox_Py);
            this.groupBox3.Location = new System.Drawing.Point(243, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 106);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "计算结果：";
            // 
            // textBox_Px
            // 
            this.textBox_Px.Location = new System.Drawing.Point(16, 24);
            this.textBox_Px.Name = "textBox_Px";
            this.textBox_Px.Size = new System.Drawing.Size(100, 25);
            this.textBox_Px.TabIndex = 0;
            // 
            // textBox_Py
            // 
            this.textBox_Py.Location = new System.Drawing.Point(16, 67);
            this.textBox_Py.Name = "textBox_Py";
            this.textBox_Py.Size = new System.Drawing.Size(100, 25);
            this.textBox_Py.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 49);
            this.button1.TabIndex = 8;
            this.button1.Text = "计算P点坐标";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存为文件ToolStripMenuItem,
            this.保存到数据库ToolStripMenuItem1});
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 保存为文件ToolStripMenuItem
            // 
            this.保存为文件ToolStripMenuItem.Name = "保存为文件ToolStripMenuItem";
            this.保存为文件ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.保存为文件ToolStripMenuItem.Text = "保存到文件";
            // 
            // 保存到数据库ToolStripMenuItem1
            // 
            this.保存到数据库ToolStripMenuItem1.Name = "保存到数据库ToolStripMenuItem1";
            this.保存到数据库ToolStripMenuItem1.Size = new System.Drawing.Size(182, 26);
            this.保存到数据库ToolStripMenuItem1.Text = "保存到数据库";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.绘制ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(706, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem1,
            this.保存ToolStripMenuItem1,
            this.数据库管理ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem1
            // 
            this.打开ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开结果文件ToolStripMenuItem});
            this.打开ToolStripMenuItem1.Image = global::测编GUI编程.Properties.Resources._1_51_文件打开;
            this.打开ToolStripMenuItem1.Name = "打开ToolStripMenuItem1";
            this.打开ToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.打开ToolStripMenuItem1.Text = "打开";
            // 
            // 打开结果文件ToolStripMenuItem
            // 
            this.打开结果文件ToolStripMenuItem.Name = "打开结果文件ToolStripMenuItem";
            this.打开结果文件ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.打开结果文件ToolStripMenuItem.Text = "打开结果文件";
            this.打开结果文件ToolStripMenuItem.Click += new System.EventHandler(this.打开结果文件ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem1
            // 
            this.保存ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存到文件ToolStripMenuItem,
            this.保存到数据库ToolStripMenuItem});
            this.保存ToolStripMenuItem1.Image = global::测编GUI编程.Properties.Resources._2_19_文件另存为;
            this.保存ToolStripMenuItem1.Name = "保存ToolStripMenuItem1";
            this.保存ToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.保存ToolStripMenuItem1.Text = "保存";
            // 
            // 保存到文件ToolStripMenuItem
            // 
            this.保存到文件ToolStripMenuItem.Name = "保存到文件ToolStripMenuItem";
            this.保存到文件ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.保存到文件ToolStripMenuItem.Text = "保存到文件";
            this.保存到文件ToolStripMenuItem.Click += new System.EventHandler(this.保存到文件ToolStripMenuItem_Click);
            // 
            // 保存到数据库ToolStripMenuItem
            // 
            this.保存到数据库ToolStripMenuItem.Name = "保存到数据库ToolStripMenuItem";
            this.保存到数据库ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.保存到数据库ToolStripMenuItem.Text = "保存到数据库";
            this.保存到数据库ToolStripMenuItem.Click += new System.EventHandler(this.保存到数据库ToolStripMenuItem_Click);
            // 
            // 数据库管理ToolStripMenuItem
            // 
            this.数据库管理ToolStripMenuItem.Image = global::测编GUI编程.Properties.Resources.数据转化;
            this.数据库管理ToolStripMenuItem.Name = "数据库管理ToolStripMenuItem";
            this.数据库管理ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.数据库管理ToolStripMenuItem.Text = "管理数据库";
            this.数据库管理ToolStripMenuItem.Click += new System.EventHandler(this.管理数据库ToolStripMenuItem_Click);
            // 
            // 绘制ToolStripMenuItem
            // 
            this.绘制ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制交会图像ToolStripMenuItem});
            this.绘制ToolStripMenuItem.Name = "绘制ToolStripMenuItem";
            this.绘制ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.绘制ToolStripMenuItem.Text = "绘制";
            // 
            // 绘制交会图像ToolStripMenuItem
            // 
            this.绘制交会图像ToolStripMenuItem.Name = "绘制交会图像ToolStripMenuItem";
            this.绘制交会图像ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.绘制交会图像ToolStripMenuItem.Text = "绘制交会图像";
            this.绘制交会图像ToolStripMenuItem.Click += new System.EventHandler(this.绘制交会图像ToolStripMenuItem_Click);
            // 
            // DistanceIntersection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 357);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_BP);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_AP);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DistanceIntersection";
            this.Text = "距离交会";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Ax;
        private System.Windows.Forms.TextBox textBox_AP;
        private System.Windows.Forms.TextBox textBox_Ay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_Bx;
        private System.Windows.Forms.TextBox textBox_By;
        private System.Windows.Forms.TextBox textBox_BP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_Px;
        private System.Windows.Forms.TextBox textBox_Py;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存为文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存到数据库ToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 保存到文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存到数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开结果文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制交会图像ToolStripMenuItem;
    }
}