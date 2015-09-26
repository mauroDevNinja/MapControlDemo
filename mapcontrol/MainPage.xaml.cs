using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace mapcontrol
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ObtenerUbicación();
        }

        private async void ObtenerUbicación()
        {
            // La siguiente función debe de ir dentro de un private async void ya que es una petición de este tipo 
            var accessStatus = await Geolocator.RequestAccessAsync();
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:

                    // Get the current location
                    Geolocator geolocator = new Geolocator();
                    Geoposition pos = await geolocator.GetGeopositionAsync();
                    Geopoint myLocation = pos.Coordinate.Point;

                    // Set map location
                    #region Ubicaciónpredeterminada
                    /* MapControlmain.Center =
                new Geopoint(new BasicGeoposition()
                {
                    //Geopoint for Seattle 
                    Latitude = 25.750291341199556,
                    Longitude = -100.28040306118169
                });
                */
                    #endregion
                    MapControlmain.Center = myLocation;

                    MapControlmain.ZoomLevel = 12;
                    MapControlmain.LandmarksVisible = true;
                    //textBlock.Text = myLocation.ToString();
                    break;

                case GeolocationAccessStatus.Denied:
                    // Handle when access to location is denied
                    break;

                case GeolocationAccessStatus.Unspecified:
                    // Handle when an unspecified error occurs
                    break;
            }
        }
    }
}
