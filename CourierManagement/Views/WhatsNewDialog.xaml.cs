﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CourierManagement.Views
{
    public sealed partial class WhatsNewDialog : ContentDialog
    {
        public WhatsNewDialog()
        {
            // TODO WTS: Update the contents of this dialog every time you release a new version of the app
            RequestedTheme = (Window.Current.Content as FrameworkElement)?.RequestedTheme ?? ElementTheme.Default;
            InitializeComponent();
        }
    }
}