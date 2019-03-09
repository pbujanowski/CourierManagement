using System;

using CourierManagement.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CourierManagement.Views
{
    public sealed partial class SendersDetailControl : UserControl
    {
        public Sender MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Sender; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(Sender), typeof(SendersDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public SendersDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as SendersDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
