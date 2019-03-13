using CourierManagement.Core.Models;
using CourierManagement.Core.Services;
using CourierManagement.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Core;

namespace CourierManagement.ViewModels
{
    public class CourierViewModel : ViewModelBase, IViewModel
    {
        /// <summary>
        /// Pole kontroli cyklu życia widoku
        /// </summary>
        private ViewLifetimeControl _viewLifetimeControl;

        /// <summary>
        /// Pole kuriera dla widoku
        /// </summary>
        private readonly Courier _courier;

        public void Initialize(ViewLifetimeControl viewLifetimeControl)
        {
            _viewLifetimeControl = viewLifetimeControl;
            _viewLifetimeControl.Released += OnViewLifeTimeControlReleased;
        }

        private async void OnViewLifeTimeControlReleased(object sender, EventArgs e)
        {
            _viewLifetimeControl.Released -= OnViewLifeTimeControlReleased;
            await WindowManagerService.Current.MainDispatcher.RunAsync(CoreDispatcherPriority.Normal, () => WindowManagerService
                .Current
                .SecondaryViews
                .Remove(_viewLifetimeControl));
        }

        /// <summary>
        /// Właściwość imienia kuriera
        /// </summary>
        public string FirstName
        {
            get { return _courier.FirstName; }
            set
            {
                _courier.FirstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        /// <summary>
        /// Właściwość nazwiska kuriera
        /// </summary>
        public string LastName
        {
            get { return _courier.LastName; }
            set
            {
                _courier.LastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        /// <summary>
        /// Konstruktor modelu widoku kuriera
        /// </summary>
        public CourierViewModel()
        {
            DataService = new CourierService();
            _courier = new Courier();
            AcceptCommand = new RelayCommand(AcceptExecute);
        }

        /// <summary>
        /// Komenda akceptująca zmiany dotyczące kuriera
        /// </summary>
        public ICommand AcceptCommand { get; set; }

        public IDataService DataService { get; set; }

        /// <summary>
        /// Metoda wykonywana przez komendę AcceptCommand
        /// </summary>
        private async void AcceptExecute()
        {
            await Task.CompletedTask;
        }
    }
}
