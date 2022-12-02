namespace 学籍管理系统
{
    partial class AdministratorManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministratorManage));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.注册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注册新用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_PwdChange = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_NewUser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.注册ToolStripMenuItem,
            this.注册新用户ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(517, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 注册ToolStripMenuItem
            // 
            this.注册ToolStripMenuItem.Name = "注册ToolStripMenuItem";
            this.注册ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.注册ToolStripMenuItem.Text = "修改密码";
            this.注册ToolStripMenuItem.Click += new System.EventHandler(this.修改密码ToolStripMenuItem_Click);
            // 
            // 注册新用户ToolStripMenuItem
            // 
            this.注册新用户ToolStripMenuItem.Name = "注册新用户ToolStripMenuItem";
            this.注册新用户ToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.注册新用户ToolStripMenuItem.Text = "注册新用户";
            this.注册新用户ToolStripMenuItem.Click += new System.EventHandler(this.注册新用户ToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(145, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 27);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "输入旧密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "输入新密码：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(145, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(100, 27);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "确认新密码：";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(145, 129);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(100, 27);
            this.textBox3.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_PwdChange);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(53, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 215);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "修改密码";
            // 
            // button_PwdChange
            // 
            this.button_PwdChange.Location = new System.Drawing.Point(145, 172);
            this.button_PwdChange.Name = "button_PwdChange";
            this.button_PwdChange.Size = new System.Drawing.Size(100, 28);
            this.button_PwdChange.TabIndex = 7;
            this.button_PwdChange.Text = "更改";
            this.button_PwdChange.UseVisualStyleBackColor = true;
            this.button_PwdChange.Click += new System.EventHandler(this.button_PwdChange_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_NewUser);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(164, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 215);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "注册";
            // 
            // button_NewUser
            // 
            this.button_NewUser.Location = new System.Drawing.Point(140, 172);
            this.button_NewUser.Name = "button_NewUser";
            this.button_NewUser.Size = new System.Drawing.Size(100, 28);
            this.button_NewUser.TabIndex = 14;
            this.button_NewUser.Text = "创建";
            this.button_NewUser.UseVisualStyleBackColor = true;
            this.button_NewUser.Click += new System.EventHandler(this.button_NewUser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "用户名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "确认密码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "密码：";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(140, 27);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 27);
            this.textBox4.TabIndex = 8;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(140, 76);
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '*';
            this.textBox6.Size = new System.Drawing.Size(100, 27);
            this.textBox6.TabIndex = 10;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(140, 125);
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '*';
            this.textBox5.Size = new System.Drawing.Size(100, 27);
            this.textBox5.TabIndex = 12;
            // 
            // AdministratorManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 331);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdministratorManage";
            this.Text = "操作员管理";
            this.Load += new System.EventHandler(this.AdministratorManage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 注册ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注册新用户ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_PwdChange;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_NewUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
    }
}