using CourierManagement.Services;
using CourierManagement.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace CourierManagement.Views
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class CourierPage : Page
    {
        private CourierViewModel ViewModel
        {
            get { return ViewModelLocator.Current.CourierViewModel; }
        }

        public CourierPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Initialize(e.Parameter as ViewLifetimeControl);
        }
    }
}