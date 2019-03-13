using CourierManagement.Core.Models;
using CourierManagement.Core.Services;
using GalaSoft.MvvmLight;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.ViewModels
{
    public class SendersViewModel : ViewModelBase, IViewModel
    {
        public IDataService DataService { get; set; }

        /// <summary>
        /// Kolekcja z wszystkimi nadawcami
        /// </summary>
        public ObservableCollection<Sender> Senders { get; set; }

        /// <summary>
        /// Właściwość z aktualnie wybranym nadawcą w widoku
        /// </summary>
        public Sender Selected { get; set; }

        /// <summary>
        /// Konstruktor modelu widoku nadawców
        /// </summary>
        public SendersViewModel()
        {
            DataService = new SenderService();
            Senders = new ObservableCollection<Sender>();
        }

        /// <summary>
        /// Asynchroniczne zadanie wczytujące wszystkich nadawców do kolekcji
        /// </summary>
        /// <param name="viewState"></param>
        /// <returns></returns>
        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            Senders.Clear();
            var data = await DataService.GetAllFromDatabaseAsync().ConfigureAwait(false);

            foreach (var item in data)
                Senders.Add((Sender)item);

            if (viewState == MasterDetailsViewState.Both)
                Selected = Senders.First();
        }
    }
}
