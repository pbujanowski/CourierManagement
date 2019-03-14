using CourierManagement.Helpers;
using CourierManagement.Services;
using GalaSoft.MvvmLight;
using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Maps;

namespace CourierManagement.ViewModels
{
    public class DeliveriesTrackingViewModel : ViewModelBase
    {
        // TODO WTS: Set your preferred default zoom level
        private const double DefaultZoomLevel = 17;

        private readonly LocationService locationService;

        // TODO WTS: Set your preferred default location if a geolock can't be found.
        private readonly BasicGeoposition defaultPosition = new BasicGeoposition()
        {
            Latitude = 47.609425,
            Longitude = -122.3417
        };

        private double zoomLevel;

        public double ZoomLevel
        {
            get { return zoomLevel; }
            set { Set(ref zoomLevel, value); }
        }

        private Geopoint center;

        public Geopoint Center
        {
            get { return center; }
            set { Set(ref center, value); }
        }

        public DeliveriesTrackingViewModel()
        {
            locationService = new LocationService();
            Center = new Geopoint(defaultPosition);
            ZoomLevel = DefaultZoomLevel;
        }

        public async Task InitializeAsync(MapControl map)
        {
            if (locationService != null)
            {
                locationService.PositionChanged += LocationService_PositionChanged;

                var initializationSuccessful = await locationService.InitializeAsync().ConfigureAwait(false);

                if (initializationSuccessful)
                {
                    await locationService.StartListeningAsync().ConfigureAwait(false);
                }

                if (initializationSuccessful && locationService.CurrentPosition != null)
                {
                    Center = locationService.CurrentPosition.Coordinate.Point;
                }
                else
                {
                    Center = new Geopoint(defaultPosition);
                }
            }

            if (map != null)
            {
                // TODO WTS: Set your map service token. If you don't have one, request from https://www.bingmapsportal.com/
                // map.MapServiceToken = string.Empty;
                AddMapIcon(map, Center, "Map_YourLocation".GetLocalized());
            }
        }

        private void LocationService_PositionChanged(object sender, Geoposition geoposition)
        {
            if (geoposition != null)
            {
                Center = geoposition.Coordinate.Point;
            }
        }

        private void AddMapIcon(MapControl map, Geopoint position, string title)
        {
            var mapIcon = new MapIcon()
            {
                Location = position,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                Title = title,
                Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/map.png")),
                ZIndex = 0
            };
            map.MapElements.Add(mapIcon);
        }

        public override void Cleanup()
        {
            if (locationService != null)
            {
                locationService.PositionChanged -= LocationService_PositionChanged;
                locationService.StopListening();
            }

            base.Cleanup();
        }
    }
}
