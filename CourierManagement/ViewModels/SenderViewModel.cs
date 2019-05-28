using CourierManagement.Core.Models;
using CourierManagement.DataAccess.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace CourierManagement.ViewModels
{
    public class SenderViewModel : ViewModelBase, IViewModel
    {
        private readonly Sender sender;

        public string FirstName
        {
            get { return sender.FirstName; }
            set
            {
                sender.FirstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return sender.LastName; }
            set
            {
                sender.LastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        public string Company
        {
            get { return sender.Company; }
            set
            {
                sender.Company = value;
                RaisePropertyChanged(nameof(Company));
            }
        }

        public string Address
        {
            get { return sender.Address; }
            set
            {
                sender.Address = value;
                RaisePropertyChanged(nameof(Address));
            }
        }

        public string City
        {
            get { return sender.City; }
            set
            {
                sender.City = value;
                RaisePropertyChanged(nameof(City));
            }
        }

        public string PostalCode
        {
            get { return sender.PostalCode; }
            set
            {
                sender.PostalCode = value;
                RaisePropertyChanged(nameof(PostalCode));
            }
        }

        public string PhoneNumber
        {
            get { return sender.PhoneNumber; }
            set
            {
                sender.PhoneNumber = value;
                RaisePropertyChanged(nameof(PhoneNumber));
            }
        }

        public string EmailAddress
        {
            get { return sender.EmailAddress; }
            set
            {
                sender.EmailAddress = value;
                RaisePropertyChanged(nameof(EmailAddress));
            }
        }

        public ICommand AcceptCommand { get; set; }

        private async void AcceptExecute()
        {
            await DataService.AddToDatabaseAsync(sender).ConfigureAwait(false);
        }

        public IDataService DataService { get; set; }

        public SenderViewModel()
        {
            sender = new Sender();
            DataService = new SenderService();
            AcceptCommand = new RelayCommand(AcceptExecute);
        }
    }
}
