using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcObjectsDemo.ContextMenu
{
    public class OpenAttributeTable : BaseCommand
    {
        IHookHelper hookHelper;
        MapControl m_mapControl;
        IMap m_map = null;
        ILayer m_layer = null;
        public OpenAttributeTable()
        {
            base.m_caption = "打开属性表";
        }

        public override void OnClick()
        {
            if (hookHelper.Hook is MapControl)
            {
                m_mapControl = hookHelper.Hook as MapControl;
                m_map = m_mapControl.Map;
                m_layer = m_mapControl.CustomProperty as ILayer;
                if (m_layer == null)
                    return;
                if (m_map == null)
                    return;
            }
            AttributeTableForm attributeTableForm = new AttributeTableForm(m_map, m_layer);
            //attributeTableForm.OpenAttributeTable(m_layer);
            attributeTableForm.ShowDialog();
            //attributeTableForm.Show();
        }

        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;
            hookHelper = new HookHelperClass();
            hookHelper.Hook = hook;
        }
    }
}
