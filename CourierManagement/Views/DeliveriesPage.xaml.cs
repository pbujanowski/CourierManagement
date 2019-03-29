using CourierManagement.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CourierManagement.Views
{
    public sealed partial class DeliveriesPage : Page
    {
        private DeliveriesViewModel ViewModel
        {
            get { return ViewModelLocator.Current.DeliveriesViewModel; }
        }

        public DeliveriesPage()
        {
            InitializeComponent();
        }
    }
}
