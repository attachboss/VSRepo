namespace 学籍管理系统
{
    partial class CourseInfor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseInfor));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_SelectAll = new System.Windows.Forms.Button();
            this.button_Select = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Update = new System.Windows.Forms.Button();
            this.button_Insert = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(26, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(703, 193);
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "课程名";
            this.columnHeader0.Width = 91;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "课程代码";
            this.columnHeader1.Width = 106;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "任课教师";
            this.columnHeader2.Width = 131;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "学分";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "成绩";
            // 
            // button_SelectAll
            // 
            this.button_SelectAll.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button_SelectAll.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SelectAll.Location = new System.Drawing.Point(613, 224);
            this.button_SelectAll.Name = "button_SelectAll";
            this.button_SelectAll.Size = new System.Drawing.Size(116, 33);
            this.button_SelectAll.TabIndex = 29;
            this.button_SelectAll.Text = "查询所有记录";
            this.button_SelectAll.UseVisualStyleBackColor = false;
            this.button_SelectAll.Click += new System.EventHandler(this.button_SelectAll_Click);
            // 
            // button_Select
            // 
            this.button_Select.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Select.Location = new System.Drawing.Point(613, 333);
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(116, 29);
            this.button_Select.TabIndex = 28;
            this.button_Select.Text = "查询记录";
            this.button_Select.UseVisualStyleBackColor = true;
            this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Delete.Location = new System.Drawing.Point(613, 298);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(116, 29);
            this.button_Delete.TabIndex = 27;
            this.button_Delete.Text = "删除记录";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Update
            // 
            this.button_Update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_Update.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Update.Location = new System.Drawing.Point(613, 263);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(116, 29);
            this.button_Update.TabIndex = 26;
            this.button_Update.Text = "修改记录";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // button_Insert
            // 
            this.button_Insert.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Insert.Location = new System.Drawing.Point(613, 368);
            this.button_Insert.Name = "button_Insert";
            this.button_Insert.Size = new System.Drawing.Size(116, 29);
            this.button_Insert.TabIndex = 25;
            this.button_Insert.Text = "添加新记录";
            this.button_Insert.UseVisualStyleBackColor = true;
            this.button_Insert.Click += new System.EventHandler(this.button_Insert_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.button_Clear);
            this.groupBox1.Location = new System.Drawing.Point(26, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 156);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(262, 63);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 25);
            this.textBox5.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(218, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "成绩";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(262, 23);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 25);
            this.textBox4.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(218, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "学分";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(81, 101);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 25);
            this.textBox3.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "任课教师";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(81, 63);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "课程代码";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "课程名";
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Exit.Location = new System.Drawing.Point(407, 91);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(81, 47);
            this.button_Exit.TabIndex = 19;
            this.button_Exit.Text = "退出";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Font = new System.Drawing.Font("华文中宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Clear.Location = new System.Drawing.Point(407, 25);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(81, 49);
            this.button_Clear.TabIndex = 18;
            this.button_Clear.Text = "清空输入信息";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // CourseInfor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 430);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_SelectAll);
            this.Controls.Add(this.button_Select);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_Insert);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CourseInfor";
            this.Text = "课程信息管理";
            this.Load += new System.EventHandler(this.CourseInfor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button_SelectAll;
        private System.Windows.Forms.Button button_Select;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.Button button_Insert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}