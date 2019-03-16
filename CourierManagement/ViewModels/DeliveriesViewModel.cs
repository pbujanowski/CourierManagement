using CourierManagement.Core.Models;
using CourierManagement.Core.Services;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CourierManagement.ViewModels
{
    public class DeliveriesViewModel : ViewModelBase, IViewModel
    {
        private readonly ObservableCollection<Delivery> deliveries;

        /// <summary>
        /// Asynchroniczne zadanie uzupełniające kolekcję z wszystkimi przesyłkami
        /// </summary>
        /// <returns></returns>
        private async void GetDeliveries()
        {
            deliveries.Clear();
            var list = await DataService.GetAllFromDatabaseAsync().ConfigureAwait(false);
            foreach (var item in list)
                deliveries.Add((Delivery)item);
        }

        public IDataService DataService { get; set; }

        /// <summary>
        /// Kolekcja przechowująca wszystkie przesyłki
        /// </summary>
        public ObservableCollection<Delivery> Deliveries
        {
            get
            {
                GetDeliveries();
                return deliveries;
            }
        }

        /// <summary>
        /// Właściwość aktualnie wybranej przesyłki w widoku
        /// </summary>
        public Delivery Selected { get; set; }

        /// <summary>
        /// Konstruktor modelu widoku przesyłek
        /// </summary>
        public DeliveriesViewModel()
        {
            DataService = new DeliveryService();
            deliveries = new ObservableCollection<Delivery>();
        }
    }
}
