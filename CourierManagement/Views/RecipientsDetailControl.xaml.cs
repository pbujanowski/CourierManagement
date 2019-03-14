using CourierManagement.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CourierManagement.Views
{
    public sealed partial class RecipientsDetailControl : UserControl
    {
        public Recipient MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Recipient; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(Recipient), typeof(RecipientsDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public RecipientsDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RecipientsDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
