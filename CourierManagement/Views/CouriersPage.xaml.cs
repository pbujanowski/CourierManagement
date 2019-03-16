using CourierManagement.Helpers;
using CourierManagement.Services;
using CourierManagement.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Windows.UI.Popups;
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
            switch (message.Notification)
            {
                case ViewModelNotificationMessages.CourierAddMessage:
                    await WindowManagerService.Current.TryShowAsViewModeAsync(ViewModelNotificationMessages.CourierAddMessage.GetLocalized(), typeof(CourierPage)).ConfigureAwait(false);
                    break;

                default:
                    var dialog = new MessageDialog("UnknownNotificationMessageReceived".GetLocalized(), "ErrorMessageTitle".GetLocalized());
                    break;
            }
        }

        private async void CouriersPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState).ConfigureAwait(false);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // Workaround for issue on MasterDetail Control. Find More info at https://github.com/Microsoft/WindowsTemplateStudio/issues/2738
            ViewModel.Selected = null;
        }
    }
}