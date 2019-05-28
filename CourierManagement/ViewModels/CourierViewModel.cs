using CourierManagement.Core.Models;
using CourierManagement.DataAccess.Services;
using CourierManagement.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
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

        public Gender Gender
        {
            get { return courier.Gender; }
            set
            {
                courier.Gender = value;
                RaisePropertyChanged(nameof(Gender));
            }
        }

        public DateTime Birthdate
        {
            get { return courier.Birthdate; }
            set
            {
                courier.Birthdate = value;
                RaisePropertyChanged(nameof(Birthdate));
            }
        }

        public string Pesel
        {
            get { return courier.Pesel; }
            set
            {
                courier.Pesel = value;
                RaisePropertyChanged(nameof(Pesel));
            }
        }

        public string Address
        {
            get { return courier.Address; }
            set
            {
                courier.Address = value;
                RaisePropertyChanged(nameof(Address));
            }
        }

        public string City
        {
            get { return courier.City; }
            set
            {
                courier.City = value;
                RaisePropertyChanged(nameof(City));
            }
        }

        public string PostalCode
        {
            get { return courier.PostalCode; }
            set
            {
                courier.PostalCode = value;
                RaisePropertyChanged(nameof(PostalCode));
            }
        }

        public string PhoneNumber
        {
            get { return courier.PhoneNumber; }
            set
            {
                courier.PhoneNumber = value;
                RaisePropertyChanged(nameof(PhoneNumber));
            }
        }

        public string EmailAddress
        {
            get { return courier.EmailAddress; }
            set
            {
                courier.EmailAddress = value;
                RaisePropertyChanged(nameof(EmailAddress));
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
            await DataService.AddToDatabaseAsync(courier).ConfigureAwait(false);
        }
    }
}
