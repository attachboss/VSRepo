using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm11._11
{
    public partial class Strip : Form
    {
        public Strip()
        {
            //ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            InitializeComponent();
        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //IMapDocument mapDoc = new MapDocumentClass();
            //OpenFileDialog ofg = new OpenFileDialog();
            //ofg.Filter = "所有文件|*.*|地图文件|*.mxd";
            //if (ofg.ShowDialog() == DialogResult.OK)
            //{
            //    string path = Path.Combine(Directory.GetCurrentDirectory(), ofg.FileName);
            //    mapDoc.Open(path, null);
            //    for (int i = 0; i < mapDoc.MapCount; i++)
            //    {
            //        IMap map = mapDoc.Map[i];
            //        for (int j = 0; j < map.LayerCount; j++)
            //        {
            //            ILayer layer = map.Layer[j];
            //            Console.WriteLine(layer.Name);
            //        }
            //    }
            //}
        }
    }
}
