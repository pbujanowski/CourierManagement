using CourierManagement.Core.Models;
using CourierManagement.Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourierManagement.ViewModels
{
    public class CouriersViewModel : ViewModelBase, IViewModel
    {
        /// <summary>
        /// Konstruktor modelu widoku kurierów
        /// </summary>
        public CouriersViewModel()
        {
            AddCourierCommand = new RelayCommand(AddCourierExecute);
            DataService = new CourierService();
            Couriers = new ObservableCollection<Courier>();
        }

        public IDataService DataService { get; set; }

        /// <summary>
        /// Kolekcja przechowująca wszystkich kurierów
        /// </summary>
        public ObservableCollection<Courier> Couriers { get; set; }

        public Courier Selected { get; set; }

        /// <summary>
        /// Asynchroniczne zadanie wczytujące wszystkich kurierów do kolekcji Couriers
        /// </summary>
        /// <param name="viewState"></param>
        /// <returns></returns>
        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            Couriers.Clear();
            var data = await DataService.GetAllFromDatabaseAsync().ConfigureAwait(false);

            foreach (var item in data)
                Couriers.Add((Courier)item);

            if (viewState == MasterDetailsViewState.Both)
                Selected = Couriers.First();
        }

        /// <summary>
        /// Komenda otwierająca nowy widok, w celu dodania nowego kuriera
        /// </summary>
        public ICommand AddCourierCommand { get; set; }

        /// <summary>
        /// Metoda wykonywana przez komendę AddCourierCommand
        /// </summary>
        private void AddCourierExecute()
        {
            Messenger.Default.Send(new NotificationMessage(ViewModelNotificationMessages.CourierAddMessage));
        }
    }
}