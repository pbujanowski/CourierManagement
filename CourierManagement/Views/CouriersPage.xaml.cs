using System;
using CourierManagement.Services;
using CourierManagement.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CourierManagement.Views
{
    public sealed partial class CouriersPage : Page
    {
        private CouriersViewModel ViewModel
        {
            get { return ViewModelLocator.Current.CouriersViewModel; }
        }

        public CouriersPage()
        {
            InitializeComponent();
            Loaded += CouriersPage_Loaded;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private async void NotificationMessageReceived(NotificationMessage message)
        {
            if (message.Notification == "AddCourier")
            {
                await WindowManagerService.Current.TryShowAsStandaloneAsync("Dodaj kuriera", typeof(CourierPage));
            }
        }

        private async void CouriersPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // Workaround for issue on MasterDetail Control. Find More info at https://github.com/Microsoft/WindowsTemplateStudio/issues/2738
            ViewModel.Selected = null;
        }
    }
}
