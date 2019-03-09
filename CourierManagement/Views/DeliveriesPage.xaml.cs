using System;

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

        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on DataGridPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public DeliveriesPage()
        {
            InitializeComponent();
        }
    }
}
