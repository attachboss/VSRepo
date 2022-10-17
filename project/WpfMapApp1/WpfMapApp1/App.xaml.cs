using Esri.ArcGISRuntime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMapApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //****************
            // Authentication for ArcGIS location services:
            // Use of ArcGIS location services, including basemaps and geocoding, requires either:
            // 1) ArcGIS identity (formerly named user): An account that is a member of an organization in ArcGIS Online or ArcGIS Enterprise
            //    giving your application permission to access the content and location services authorized to an existing ArcGIS user's account.
            // 2) API key: A permanent token that grants your application access to ArcGIS location services.
            //    Create a new API key or access existing API keys from your ArcGIS for Developers
            //    dashboard (https://links.esri.com/arcgis-api-keys) then set:
            //    ArcGISRuntimeEnvironment.ApiKey = "[Your ArcGIS location services API Key]";
            // For more information see https://links.esri.com/arcgis-runtime-security-auth.
            //
            // Licensing:
            // Production deployment of applications built with ArcGIS Runtime requires you to license ArcGIS Runtime functionality.
            // For more information see https://links.esri.com/arcgis-runtime-license-and-deploy.
            //   ArcGISRuntimeEnvironment.SetLicense(string licenseString);
            // or 
            //   ArcGISRuntimeEnvironment.SetLicense(await myArcGISPortal.GetLicenseInfoAsync());
            //****************

            try
            {
                // Initialize the ArcGIS Runtime before any components are created.
                ArcGISRuntimeEnvironment.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ArcGIS Runtime initialization failed.");

                // Exit application
                this.Shutdown();
            }
        }
    }
}
