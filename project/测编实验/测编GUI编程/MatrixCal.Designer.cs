namespace 测编GUI编程
{
    partial class MatrixCal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatrixCal));
            this.textBox_A = new System.Windows.Forms.TextBox();
            this.textBox_B = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox_Result = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_A
            // 
            this.textBox_A.Location = new System.Drawing.Point(32, 55);
            this.textBox_A.Multiline = true;
            this.textBox_A.Name = "textBox_A";
            this.textBox_A.Size = new System.Drawing.Size(160, 147);
            this.textBox_A.TabIndex = 0;
            // 
            // textBox_B
            // 
            this.textBox_B.Location = new System.Drawing.Point(280, 55);
            this.textBox_B.Multiline = true;
            this.textBox_B.Name = "textBox_B";
            this.textBox_B.Size = new System.Drawing.Size(160, 147);
            this.textBox_B.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "求逆"});
            this.comboBox1.Location = new System.Drawing.Point(198, 118);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(76, 23);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // textBox_Result
            // 
            this.textBox_Result.Location = new System.Drawing.Point(560, 55);
            this.textBox_Result.Multiline = true;
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Result.Size = new System.Drawing.Size(160, 147);
            this.textBox_Result.TabIndex = 4;
            this.textBox_Result.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "（输入矩阵时每个元素之间用空格隔开）";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(447, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 43);
            this.button1.TabIndex = 6;
            this.button1.Text = "计算结果：";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(446, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 43);
            this.button2.TabIndex = 7;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MatrixCal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 335);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Result);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox_B);
            this.Controls.Add(this.textBox_A);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MatrixCal";
            this.Text = "矩阵计算";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_A;
        private System.Windows.Forms.TextBox textBox_B;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}