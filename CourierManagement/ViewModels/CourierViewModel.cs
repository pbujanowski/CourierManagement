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
        private ViewLifetimeControl viewLifetimeControl;

        /// <summary>
        /// Pole kuriera dla widoku
        /// </summary>
        private readonly Courier courier;

        public void Initialize(ViewLifetimeControl viewLifetimeControl)
        {
            this.viewLifetimeControl = viewLifetimeControl;
            this.viewLifetimeControl.Released += OnViewLifeTimeControlReleased;
        }

        private async void OnViewLifeTimeControlReleased(object sender, EventArgs e)
        {
            viewLifetimeControl.Released -= OnViewLifeTimeControlReleased;
            await WindowManagerService.Current.MainDispatcher.RunAsync(CoreDispatcherPriority.Normal, () => WindowManagerService
                .Current
                .SecondaryViews
                .Remove(viewLifetimeControl));
        }

        /// <summary>
        /// Właściwość imienia kuriera
        /// </summary>
        public string FirstName
        {
            get { return courier.FirstName; }
            set
            {
                courier.FirstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        /// <summary>
        /// Właściwość nazwiska kuriera
        /// </summary>
        public string LastName
        {
            get { return courier.LastName; }
            set
            {
                courier.LastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        /// <summary>
        /// Konstruktor modelu widoku kuriera
        /// </summary>
        public CourierViewModel()
        {
            DataService = new CourierService();
            courier = new Courier();
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