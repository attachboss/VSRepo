namespace 学籍管理系统
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelAdmin = new System.Windows.Forms.Label();
            this.labelPsw = new System.Windows.Forms.Label();
            this.textBoxImportAdmin = new System.Windows.Forms.TextBox();
            this.textBoxImportPsw = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(88, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.AutoSize = true;
            this.buttonExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonExit.Font = new System.Drawing.Font("华文中宋", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExit.Location = new System.Drawing.Point(606, 325);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(55, 30);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "退出";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogin.AutoSize = true;
            this.buttonLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonLogin.Font = new System.Drawing.Font("华文中宋", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLogin.Location = new System.Drawing.Point(606, 244);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(55, 30);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "登陆";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelAdmin
            // 
            this.labelAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAdmin.AutoSize = true;
            this.labelAdmin.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAdmin.Location = new System.Drawing.Point(178, 244);
            this.labelAdmin.Name = "labelAdmin";
            this.labelAdmin.Size = new System.Drawing.Size(73, 23);
            this.labelAdmin.TabIndex = 3;
            this.labelAdmin.Text = "用户名";
            // 
            // labelPsw
            // 
            this.labelPsw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPsw.AutoSize = true;
            this.labelPsw.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPsw.Location = new System.Drawing.Point(178, 325);
            this.labelPsw.Name = "labelPsw";
            this.labelPsw.Size = new System.Drawing.Size(66, 23);
            this.labelPsw.TabIndex = 4;
            this.labelPsw.Text = "密  码";
            // 
            // textBoxImportAdmin
            // 
            this.textBoxImportAdmin.Location = new System.Drawing.Point(301, 246);
            this.textBoxImportAdmin.Name = "textBoxImportAdmin";
            this.textBoxImportAdmin.Size = new System.Drawing.Size(242, 25);
            this.textBoxImportAdmin.TabIndex = 5;
            // 
            // textBoxImportPsw
            // 
            this.textBoxImportPsw.Location = new System.Drawing.Point(301, 327);
            this.textBoxImportPsw.Name = "textBoxImportPsw";
            this.textBoxImportPsw.PasswordChar = '*';
            this.textBoxImportPsw.Size = new System.Drawing.Size(242, 25);
            this.textBoxImportPsw.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("华文中宋", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(421, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(316, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "学 籍 信 息 管 理 系 统";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("华文中宋", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(434, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "地球科学与环境工程学院";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文中宋", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(298, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "用户名、密码初始为1和1";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxImportPsw);
            this.Controls.Add(this.textBoxImportAdmin);
            this.Controls.Add(this.labelPsw);
            this.Controls.Add(this.labelAdmin);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "登录";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonExit;
        protected internal System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelAdmin;
        private System.Windows.Forms.Label labelPsw;
        private System.Windows.Forms.TextBox textBoxImportAdmin;
        private System.Windows.Forms.TextBox textBoxImportPsw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}