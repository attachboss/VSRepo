namespace 测编GUI编程
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算坐标方位角及距离ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.交会计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.前方交会ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.距离交会ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.侧方交会ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.角度转换计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.矩阵运算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.子窗体横向排列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.子窗体纵向排列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭所有子窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助菜单项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录ToolStripMenuItem,
            this.系统ToolStripMenuItem,
            this.功能ToolStripMenuItem,
            this.窗体ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 登录ToolStripMenuItem
            // 
            this.登录ToolStripMenuItem.Name = "登录ToolStripMenuItem";
            this.登录ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.登录ToolStripMenuItem.Text = "登录";
            this.登录ToolStripMenuItem.Click += new System.EventHandler(this.登录ToolStripMenuItem_Click);
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.系统ToolStripMenuItem.Text = "系统";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 功能ToolStripMenuItem
            // 
            this.功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.计算坐标方位角及距离ToolStripMenuItem,
            this.交会计算ToolStripMenuItem,
            this.角度转换计算ToolStripMenuItem,
            this.矩阵运算ToolStripMenuItem});
            this.功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            this.功能ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.功能ToolStripMenuItem.Text = "功能";
            // 
            // 计算坐标方位角及距离ToolStripMenuItem
            // 
            this.计算坐标方位角及距离ToolStripMenuItem.Name = "计算坐标方位角及距离ToolStripMenuItem";
            this.计算坐标方位角及距离ToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.计算坐标方位角及距离ToolStripMenuItem.Text = "坐标方位角及距离计算";
            this.计算坐标方位角及距离ToolStripMenuItem.Click += new System.EventHandler(this.计算坐标方位角及距离ToolStripMenuItem_Click);
            // 
            // 交会计算ToolStripMenuItem
            // 
            this.交会计算ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.前方交会ToolStripMenuItem,
            this.距离交会ToolStripMenuItem,
            this.侧方交会ToolStripMenuItem});
            this.交会计算ToolStripMenuItem.Name = "交会计算ToolStripMenuItem";
            this.交会计算ToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.交会计算ToolStripMenuItem.Text = "交会计算";
            // 
            // 前方交会ToolStripMenuItem
            // 
            this.前方交会ToolStripMenuItem.Name = "前方交会ToolStripMenuItem";
            this.前方交会ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.前方交会ToolStripMenuItem.Text = "前方交会";
            this.前方交会ToolStripMenuItem.Click += new System.EventHandler(this.前方交会ToolStripMenuItem_Click);
            // 
            // 距离交会ToolStripMenuItem
            // 
            this.距离交会ToolStripMenuItem.Name = "距离交会ToolStripMenuItem";
            this.距离交会ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.距离交会ToolStripMenuItem.Text = "距离交会";
            this.距离交会ToolStripMenuItem.Click += new System.EventHandler(this.距离交会ToolStripMenuItem_Click);
            // 
            // 侧方交会ToolStripMenuItem
            // 
            this.侧方交会ToolStripMenuItem.Name = "侧方交会ToolStripMenuItem";
            this.侧方交会ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.侧方交会ToolStripMenuItem.Text = "侧方交会";
            this.侧方交会ToolStripMenuItem.Click += new System.EventHandler(this.侧方交会ToolStripMenuItem_Click);
            // 
            // 角度转换计算ToolStripMenuItem
            // 
            this.角度转换计算ToolStripMenuItem.Name = "角度转换计算ToolStripMenuItem";
            this.角度转换计算ToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.角度转换计算ToolStripMenuItem.Text = "角度转换计算";
            this.角度转换计算ToolStripMenuItem.Click += new System.EventHandler(this.角度转换计算ToolStripMenuItem_Click);
            // 
            // 矩阵运算ToolStripMenuItem
            // 
            this.矩阵运算ToolStripMenuItem.Name = "矩阵运算ToolStripMenuItem";
            this.矩阵运算ToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.矩阵运算ToolStripMenuItem.Text = "矩阵运算";
            this.矩阵运算ToolStripMenuItem.Click += new System.EventHandler(this.矩阵运算ToolStripMenuItem_Click);
            // 
            // 窗体ToolStripMenuItem
            // 
            this.窗体ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.子窗体横向排列ToolStripMenuItem,
            this.子窗体纵向排列ToolStripMenuItem,
            this.关闭所有子窗体ToolStripMenuItem});
            this.窗体ToolStripMenuItem.Name = "窗体ToolStripMenuItem";
            this.窗体ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.窗体ToolStripMenuItem.Text = "窗体";
            // 
            // 子窗体横向排列ToolStripMenuItem
            // 
            this.子窗体横向排列ToolStripMenuItem.Name = "子窗体横向排列ToolStripMenuItem";
            this.子窗体横向排列ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.子窗体横向排列ToolStripMenuItem.Text = "横向排列";
            this.子窗体横向排列ToolStripMenuItem.Click += new System.EventHandler(this.横向排列ToolStripMenuItem_Click);
            // 
            // 子窗体纵向排列ToolStripMenuItem
            // 
            this.子窗体纵向排列ToolStripMenuItem.Name = "子窗体纵向排列ToolStripMenuItem";
            this.子窗体纵向排列ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.子窗体纵向排列ToolStripMenuItem.Text = "纵向排列";
            this.子窗体纵向排列ToolStripMenuItem.Click += new System.EventHandler(this.纵向排列ToolStripMenuItem_Click);
            // 
            // 关闭所有子窗体ToolStripMenuItem
            // 
            this.关闭所有子窗体ToolStripMenuItem.Name = "关闭所有子窗体ToolStripMenuItem";
            this.关闭所有子窗体ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.关闭所有子窗体ToolStripMenuItem.Text = "关闭所有子窗体";
            this.关闭所有子窗体ToolStripMenuItem.Click += new System.EventHandler(this.关闭所有子窗体ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.帮助菜单项ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 帮助菜单项ToolStripMenuItem
            // 
            this.帮助菜单项ToolStripMenuItem.Name = "帮助菜单项ToolStripMenuItem";
            this.帮助菜单项ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.帮助菜单项ToolStripMenuItem.Text = "帮助菜单项";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "测绘计算应用程序";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 登录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算坐标方位角及距离ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 交会计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 角度转换计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 矩阵运算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 窗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 子窗体横向排列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 子窗体纵向排列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭所有子窗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助菜单项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 前方交会ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 距离交会ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 侧方交会ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}

