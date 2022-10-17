namespace 测编GUI编程
{
    partial class DataUphold
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataUphold));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.servingApplicationDBDataSet = new 测编GUI编程.ServingApplicationDBDataSet();
            this.pointPosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pointPosTableAdapter = new 测编GUI编程.ServingApplicationDBDataSetTableAdapters.PointPosTableAdapter();
            this.pnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pattributeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servingApplicationDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointPosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pnoDataGridViewTextBoxColumn,
            this.pnameDataGridViewTextBoxColumn,
            this.pxDataGridViewTextBoxColumn,
            this.pyDataGridViewTextBoxColumn,
            this.puseDataGridViewTextBoxColumn,
            this.pattributeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pointPosBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(775, 425);
            this.dataGridView1.TabIndex = 0;
            // 
            // servingApplicationDBDataSet
            // 
            this.servingApplicationDBDataSet.DataSetName = "ServingApplicationDBDataSet";
            this.servingApplicationDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pointPosBindingSource
            // 
            this.pointPosBindingSource.DataMember = "PointPos";
            this.pointPosBindingSource.DataSource = this.servingApplicationDBDataSet;
            // 
            // pointPosTableAdapter
            // 
            this.pointPosTableAdapter.ClearBeforeFill = true;
            // 
            // pnoDataGridViewTextBoxColumn
            // 
            this.pnoDataGridViewTextBoxColumn.DataPropertyName = "Pno";
            this.pnoDataGridViewTextBoxColumn.HeaderText = "Pno";
            this.pnoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pnoDataGridViewTextBoxColumn.Name = "pnoDataGridViewTextBoxColumn";
            this.pnoDataGridViewTextBoxColumn.Width = 125;
            // 
            // pnameDataGridViewTextBoxColumn
            // 
            this.pnameDataGridViewTextBoxColumn.DataPropertyName = "Pname";
            this.pnameDataGridViewTextBoxColumn.HeaderText = "Pname";
            this.pnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pnameDataGridViewTextBoxColumn.Name = "pnameDataGridViewTextBoxColumn";
            this.pnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // pxDataGridViewTextBoxColumn
            // 
            this.pxDataGridViewTextBoxColumn.DataPropertyName = "P_x";
            this.pxDataGridViewTextBoxColumn.HeaderText = "P_x";
            this.pxDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pxDataGridViewTextBoxColumn.Name = "pxDataGridViewTextBoxColumn";
            this.pxDataGridViewTextBoxColumn.Width = 125;
            // 
            // pyDataGridViewTextBoxColumn
            // 
            this.pyDataGridViewTextBoxColumn.DataPropertyName = "P_y";
            this.pyDataGridViewTextBoxColumn.HeaderText = "P_y";
            this.pyDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pyDataGridViewTextBoxColumn.Name = "pyDataGridViewTextBoxColumn";
            this.pyDataGridViewTextBoxColumn.Width = 125;
            // 
            // puseDataGridViewTextBoxColumn
            // 
            this.puseDataGridViewTextBoxColumn.DataPropertyName = "Puse";
            this.puseDataGridViewTextBoxColumn.HeaderText = "Puse";
            this.puseDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.puseDataGridViewTextBoxColumn.Name = "puseDataGridViewTextBoxColumn";
            this.puseDataGridViewTextBoxColumn.Width = 125;
            // 
            // pattributeDataGridViewTextBoxColumn
            // 
            this.pattributeDataGridViewTextBoxColumn.DataPropertyName = "Pattribute";
            this.pattributeDataGridViewTextBoxColumn.HeaderText = "Pattribute";
            this.pattributeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pattributeDataGridViewTextBoxColumn.Name = "pattributeDataGridViewTextBoxColumn";
            this.pattributeDataGridViewTextBoxColumn.Width = 125;
            // 
            // DataUphold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataUphold";
            this.Text = "DataUphold";
            this.Load += new System.EventHandler(this.DataUphold_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servingApplicationDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointPosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ServingApplicationDBDataSet servingApplicationDBDataSet;
        private System.Windows.Forms.BindingSource pointPosBindingSource;
        private ServingApplicationDBDataSetTableAdapters.PointPosTableAdapter pointPosTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn pnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn puseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pattributeDataGridViewTextBoxColumn;
    }
}