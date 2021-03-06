﻿using CourierManagement.Helpers;
using CourierManagement.Services;
using GalaSoft.MvvmLight;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Core;
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
            Latitude = 50.2904235,
            Longitude = 18.6667979
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
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Center = new Geopoint(defaultPosition));
                }
            }

            if (map != null)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    map.MapServiceToken = "MRGhNHkURhM3nXKl6vfz~vl-AJVE587dSBmETW3LrYQ~AjRLU7w1eidW1gP_EVhN4UahTdXwfr9uGHHNR_tsy-anMHGOt8zAogL5hzOnqcL9";
                    AddMapIcon(map, Center, "Map_YourLocation".GetLocalized());
                });
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