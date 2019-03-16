using CourierManagement.Core.Models;
using CourierManagement.Core.Services;
using GalaSoft.MvvmLight;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.ViewModels
{
    public class RecipientsViewModel : ViewModelBase, IViewModel
    {
        public IDataService DataService { get; set; }

        /// <summary>
        /// Kolekcja z wszystkimi odbiorcami
        /// </summary>
        public ObservableCollection<Recipient> Recipients { get; set; }

        /// <summary>
        /// Właściwość z aktualnie wybranym odbiorcą w widoku
        /// </summary>
        public Recipient Selected { get; set; }

        /// <summary>
        /// Konstruktor modelu widoku odbiorców
        /// </summary>
        public RecipientsViewModel()
        {
            DataService = new RecipientService();
            Recipients = new ObservableCollection<Recipient>();
        }

        /// <summary>
        /// Asynchroniczne zadanie wczytujące wszystkich odbiorców do kolekcji
        /// </summary>
        /// <param name="viewState"></param>
        /// <returns></returns>
        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            Recipients.Clear();
            var data = await DataService.GetAllFromDatabaseAsync().ConfigureAwait(false);

            foreach (var item in data)
                Recipients.Add((Recipient)item);

            if (viewState == MasterDetailsViewState.Both)
                Selected = Recipients.First();
        }
    }
}