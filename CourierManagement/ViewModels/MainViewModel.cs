using CourierManagement.DataAccess.Services;
using GalaSoft.MvvmLight;

namespace CourierManagement.ViewModels
{
    /// <summary>
    /// Model widoku głównej zakładki
    /// </summary>
    public class MainViewModel : ViewModelBase, IViewModel
    {
        /// <summary>
        /// Konstruktor modelu widoku głównej zakładki
        /// </summary>
        public MainViewModel()
        {
        }

        public IDataService DataService { get; set; }
    }
}