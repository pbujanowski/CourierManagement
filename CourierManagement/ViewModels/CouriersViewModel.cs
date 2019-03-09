using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using CourierManagement.Core.Models;
using CourierManagement.Core.Services;

using GalaSoft.MvvmLight;

using Microsoft.Toolkit.Uwp.UI.Controls;

namespace CourierManagement.ViewModels
{
    public class CouriersViewModel : ViewModelBase
    {
        /// <summary>
        /// Prywatne pole dla aktualnie wybranego kuriera
        /// </summary>
        private Courier _selected;
        /// <summary>
        /// Właściwość dla aktualnie wybranego kuriera
        /// </summary>
        public Courier Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }
        /// <summary>
        /// Kolekcja przechowująca wszystkich kurierów
        /// </summary>
        public ObservableCollection<Courier> Couriers { get; private set; }
        /// <summary>
        /// Konstruktor modelu widoku kurierów
        /// </summary>
        public CouriersViewModel()
        {
            Couriers = new ObservableCollection<Courier>();
        }
        /// <summary>
        /// Asynchroniczne zadanie wczytujące wszystkich kurierów do kolekcji Couriers
        /// </summary>
        /// <param name="viewState"></param>
        /// <returns></returns>
        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            //SampleItems.Clear();
            Couriers.Clear();
            var data = await CourierService.GetCouriersAsync();

            foreach (var item in data)
            {
                Couriers.Add(item);
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = Couriers.First();
            }
        }
    }
}
