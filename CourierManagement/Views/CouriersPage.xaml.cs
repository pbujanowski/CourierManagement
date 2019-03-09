using System;

using CourierManagement.ViewModels;

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
