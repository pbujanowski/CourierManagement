using CourierManagement.Core.Models;
using CourierManagement.Core.Services;
using GalaSoft.MvvmLight;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (_source == null)
                _source = new ObservableCollection<Delivery>();
            _source.Clear();

            var data = await DeliveryService.GetDeliveriesAsync();
            foreach (var item in data)
                _source.Add(item);
        }
    }
}
