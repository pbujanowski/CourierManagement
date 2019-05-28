using CourierManagement.Core.Models;
using CourierManagement.DataAccess.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace CourierManagement.ViewModels
{
    public class RecipientViewModel : ViewModelBase, IViewModel
    {
        private readonly Recipient recipient;

        public string FirstName
        {
            get { return recipient.FirstName; }
            set
            {
                recipient.FirstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return recipient.LastName; }
            set
            {
                recipient.LastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        public string Company
        {
            get { return recipient.Company; }
            set
            {
                recipient.Company = value;
                RaisePropertyChanged(nameof(Company));
            }
        }

        public string Address
        {
            get { return recipient.Address; }
            set
            {
                recipient.Address = value;
                RaisePropertyChanged(nameof(Address));
            }
        }

        public string City
        {
            get { return recipient.City; }
            set
            {
                recipient.City = value;
                RaisePropertyChanged(nameof(City));
            }
        }

        public string PostalCode
        {
            get { return recipient.PostalCode; }
            set
            {
                recipient.PostalCode = value;
                RaisePropertyChanged(nameof(PostalCode));
            }
        }

        public string PhoneNumber
        {
            get { return recipient.PhoneNumber; }
            set
            {
                recipient.PhoneNumber = value;
                RaisePropertyChanged(nameof(PhoneNumber));
            }
        }

        public string EmailAddress
        {
            get { return recipient.EmailAddress; }
            set
            {
                recipient.EmailAddress = value;
                RaisePropertyChanged(nameof(EmailAddress));
            }
        }

        public ICommand AcceptCommand { get; set; }

        private async void AcceptExecute()
        {
            await DataService.AddToDatabaseAsync(recipient).ConfigureAwait(false);
        }

        public IDataService DataService { get; set; }

        public RecipientViewModel()
        {
            recipient = new Recipient();
            DataService = new RecipientService();
            AcceptCommand = new RelayCommand(AcceptExecute);
        }
    }
}
