using CourierManagement.Core.Services;

namespace CourierManagement.ViewModels
{
    /// <summary>
    /// Interfejs modelu widoku
    /// </summary>
    public interface IViewModel
    {
        /// <summary>
        /// Właściwość usługi danych, odpowiedzialnej za przesyłanie danych między aplikacją a bazą danych
        /// </summary>
        IDataService DataService { get; set; }
    }
}