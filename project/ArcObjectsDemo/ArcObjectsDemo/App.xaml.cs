using ESRI.ArcGIS.esriSystem;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ArcObjectsDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            InitializeEngineLicense();
        }

        private void InitializeEngineLicense()
        {
            AoInitialize aoi = new AoInitializeClass();

            //more license choices could be included here
            esriLicenseProductCode productCode = esriLicenseProductCode.esriLicenseProductCodeEngine;
            if (aoi.IsProductCodeAvailable(productCode) == esriLicenseStatus.esriLicenseAvailable)
            {
                aoi.Initialize(productCode);
            }
        }
    }
}
