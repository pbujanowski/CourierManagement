using System;

using CourierManagement.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CourierManagement.Views
{
    public sealed partial class CouriersDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(CouriersDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public CouriersDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CouriersDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
