
namespace WindowsForm11._11
{
    partial class DoYouLoveMe
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
            this.button1 = new System.Windows.Forms.Button();
            this.dont_love = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "爱";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dont_love
            // 
            this.dont_love.Location = new System.Drawing.Point(449, 179);
            this.dont_love.Name = "dont_love";
            this.dont_love.Size = new System.Drawing.Size(75, 23);
            this.dont_love.TabIndex = 1;
            this.dont_love.Text = "不爱";
            this.dont_love.UseVisualStyleBackColor = true;
            this.dont_love.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            // 
            // DoYouLoveMe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dont_love);
            this.Controls.Add(this.button1);
            this.Name = "DoYouLoveMe";
            this.Text = "DoYouLoveMe";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button dont_love;
    }
}