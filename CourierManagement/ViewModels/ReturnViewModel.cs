using CourierManagement.Core.Models;
using CourierManagement.DataAccess.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace CourierManagement.ViewModels
{
    public class ReturnViewModel : ViewModelBase, IViewModel
    {
        private readonly Return deliveryReturn;

        public Delivery Delivery
        {
            get { return deliveryReturn.Delivery; }
            set
            {
                deliveryReturn.Delivery = value;
                RaisePropertyChanged(nameof(Delivery));
            }
        }

        public decimal Cost
        {
            get { return deliveryReturn.Cost; }
            set
            {
                deliveryReturn.Cost = value;
                RaisePropertyChanged(nameof(Cost));
            }
        }

        public DateTime AcceptanceDate
        {
            get { return deliveryReturn.AcceptanceDate; }
            set
            {
                deliveryReturn.AcceptanceDate = value;
                RaisePropertyChanged(nameof(AcceptanceDate));
            }
        }

        public ICommand AcceptCommand { get; set; }

        private async void AcceptExecute()
        {
            await DataService.AddToDatabaseAsync(deliveryReturn).ConfigureAwait(false);
        }

        public IDataService DataService { get; set; }

        public ReturnViewModel()
        {
            deliveryReturn = new Return();
            DataService = new ReturnService();
            AcceptCommand = new RelayCommand(AcceptExecute);
        }
    }
}
