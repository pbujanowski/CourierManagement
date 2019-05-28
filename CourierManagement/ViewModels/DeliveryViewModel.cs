using CourierManagement.Core.Models;
using CourierManagement.DataAccess.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace CourierManagement.ViewModels
{
    public class DeliveryViewModel : ViewModelBase, IViewModel
    {
        private readonly Delivery delivery;

        public Sender Sender
        {
            get { return delivery.Sender; }
            set
            {
                delivery.Sender = value;
                RaisePropertyChanged(nameof(Sender));
            }
        }

        public Recipient Recipient
        {
            get { return delivery.Recipient; }
            set
            {
                delivery.Recipient = value;
                RaisePropertyChanged(nameof(Recipient));
            }
        }

        public Courier DeliveryCourier
        {
            get { return delivery.DeliveryCourier; }
            set
            {
                delivery.DeliveryCourier = value;
                RaisePropertyChanged(nameof(DeliveryCourier));
            }
        }

        public DateTime AcceptanceDate
        {
            get { return delivery.AcceptanceDate; }
            set
            {
                delivery.AcceptanceDate = value;
                RaisePropertyChanged(nameof(AcceptanceDate));
            }
        }

        public int Length
        {
            get { return delivery.Length; }
            set
            {
                delivery.Length = value;
                RaisePropertyChanged(nameof(Length));
            }
        }

        public int Width
        {
            get { return delivery.Width; }
            set
            {
                delivery.Width = value;
                RaisePropertyChanged(nameof(Width));
            }
        }

        public int Height
        {
            get { return delivery.Height; }
            set
            {
                delivery.Height = value;
                RaisePropertyChanged(nameof(Height));
            }
        }

        public int Weight
        {
            get { return delivery.Weight; }
            set
            {
                delivery.Weight = value;
                RaisePropertyChanged(nameof(Weight));
            }
        }

        public bool IsFragile
        {
            get { return delivery.IsFragile; }
            set
            {
                delivery.IsFragile = value;
                RaisePropertyChanged(nameof(IsFragile));
            }
        }

        public bool IsInsured
        {
            get { return delivery.IsInsured; }
            set
            {
                delivery.IsInsured = value;
                RaisePropertyChanged(nameof(IsInsured));
            }
        }

        public decimal Cost
        {
            get { return delivery.Cost; }
            set
            {
                delivery.Cost = value;
                RaisePropertyChanged(nameof(Cost));
            }
        }

        public decimal InsuranceCost
        {
            get { return delivery.InsuranceCost; }
            set
            {
                delivery.InsuranceCost = value;
                RaisePropertyChanged(nameof(InsuranceCost));
            }
        }

        public IDataService DataService { get; set; }

        public ICommand AcceptCommand { get; set; }

        private async void AcceptExecute()
        {
            await DataService.AddToDatabaseAsync(delivery).ConfigureAwait(false);
        }

        public DeliveryViewModel()
        {
            delivery = new Delivery();
            DataService = new DeliveryService();
            AcceptCommand = new RelayCommand(AcceptExecute);
        }
    }
}
