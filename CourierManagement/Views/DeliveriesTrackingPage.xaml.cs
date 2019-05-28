using CourierManagement.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CourierManagement.Views
{
    public sealed partial class DeliveriesTrackingPage : Page
    {
        private DeliveriesTrackingViewModel ViewModel
        {
            get { return ViewModelLocator.Current.DeliveriesTrackingViewModel; }
        }

        public DeliveriesTrackingPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.InitializeAsync(mapControl).ConfigureAwait(false);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.Cleanup();
        }
    }
}