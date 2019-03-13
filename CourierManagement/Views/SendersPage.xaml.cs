using CourierManagement.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CourierManagement.Views
{
    public sealed partial class SendersPage : Page
    {
        private SendersViewModel ViewModel
        {
            get { return ViewModelLocator.Current.SendersViewModel; }
        }

        public SendersPage()
        {
            InitializeComponent();
            Loaded += SendersPage_Loaded;
        }

        private async void SendersPage_Loaded(object sender, RoutedEventArgs e)
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