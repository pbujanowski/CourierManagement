using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace CourierManagement.ViewModels
{
    /// <summary>
    /// Klasa głównego modelu widoku aplikacji
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Konstruktor głównego modelu widoku
        /// </summary>
        public MainViewModel()
        {
            this.SayHelloCommand = new RelayCommand(SayHelloExecute);
        }
        /// <summary>
        /// Przykładowa komenda (wyświetlająca okno dialogowe), która umożliwia kontrolce (w tym przypadku przyciskowi) na wywołanie zdarzenia
        /// </summary>
        public ICommand SayHelloCommand { get; set; }
        /// <summary>
        /// Metoda, która wykonywana jest w trakcie wywoływania odpowiedniego zdarzenia (w tym przypadku naciśnięcie przycisku)
        /// </summary>
        private async void SayHelloExecute()
        {
            var dialog = new MessageDialog("Hello world!", "Welcome message");
            await dialog.ShowAsync();
        }
    }
}
