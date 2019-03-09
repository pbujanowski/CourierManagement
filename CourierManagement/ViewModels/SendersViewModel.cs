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
    public class SendersViewModel : ViewModelBase
    {
        private Sender _selected;
        public Sender Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }
        public ObservableCollection<Sender> Senders { get; private set; } = new ObservableCollection<Sender>();
        public SendersViewModel()
        {
        }
        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            Senders.Clear();
            var data = await SenderService.GetSendersAsync();

            foreach (var item in data)
                Senders.Add(item);

            if (viewState == MasterDetailsViewState.Both)
                Selected = Senders.First();
        }
    }
}
