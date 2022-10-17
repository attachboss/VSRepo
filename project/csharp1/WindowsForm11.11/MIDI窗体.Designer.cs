
namespace WindowsForm11._11
{
    partial class MIDI窗体
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.显示子窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.横向排列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.纵向排列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示子窗体ToolStripMenuItem,
            this.横向排列ToolStripMenuItem,
            this.纵向排列ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 显示子窗体ToolStripMenuItem
            // 
            this.显示子窗体ToolStripMenuItem.Name = "显示子窗体ToolStripMenuItem";
            this.显示子窗体ToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.显示子窗体ToolStripMenuItem.Text = "显示子窗体";
            this.显示子窗体ToolStripMenuItem.Click += new System.EventHandler(this.显示子窗体ToolStripMenuItem_Click);
            // 
            // 横向排列ToolStripMenuItem
            // 
            this.横向排列ToolStripMenuItem.Name = "横向排列ToolStripMenuItem";
            this.横向排列ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.横向排列ToolStripMenuItem.Text = "横向排列";
            this.横向排列ToolStripMenuItem.Click += new System.EventHandler(this.横向排列ToolStripMenuItem_Click);
            // 
            // 纵向排列ToolStripMenuItem
            // 
            this.纵向排列ToolStripMenuItem.Name = "纵向排列ToolStripMenuItem";
            this.纵向排列ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.纵向排列ToolStripMenuItem.Text = "纵向排列";
            this.纵向排列ToolStripMenuItem.Click += new System.EventHandler(this.纵向排列ToolStripMenuItem_Click);
            // 
            // MIDI窗体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MIDI窗体";
            this.Text = "单选和多选";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示子窗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 横向排列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 纵向排列ToolStripMenuItem;
    }
}