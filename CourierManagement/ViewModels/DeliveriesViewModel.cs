using CourierManagement.Core.Models;
using CourierManagement.Core.Services;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace CourierManagement.ViewModels
{
    public class DeliveriesViewModel : ViewModelBase
    {
        private Delivery _selected;

        public Delivery Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        private ObservableCollection<Delivery> _source;

        public ObservableCollection<Delivery> Source
        {
            get
            {
                GetDeliveries();
                return _source;
            }
            set { Set(ref _source, value); }
        }

        private async void GetDeliveries()
        {
            (_source ?? (_source = new ObservableCollection<Delivery>())).Clear();

            var data = await DeliveryService.GetDeliveriesAsync().ConfigureAwait(false);
            foreach (var item in data)
                _source.Add(item);
        }
    }
}
