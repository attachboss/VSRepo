using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 测编GUI编程
{
    public partial class DataUphold : Form
    {
        public DataUphold()
        {
            InitializeComponent();
        }

        private void DataUphold_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: 这行代码将数据加载到表“servingApplicationDBDataSet.PointPos”中。您可以根据需要移动或删除它。
                this.pointPosTableAdapter.Fill(this.servingApplicationDBDataSet.PointPos);
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }

        }
    }
}
