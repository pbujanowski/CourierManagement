using CourierManagement.Activation;
using CourierManagement.Helpers;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Notifications;
using Windows.UI.Popups;

namespace CourierManagement.Services
{
    /// <summary>
    /// Usługa dla obsługi powiadomień w systemie Windows
    /// </summary>
    internal partial class ToastNotificationsService : ActivationHandler<ToastNotificationActivatedEventArgs>
    {
        /// <summary>
        /// Metoda wyświetlająca powiadomienie w systemie Windows przekazane jako parametr
        /// </summary>
        /// <param name="toastNotification"></param>
        public async Task ShowToastNotificationAsync(ToastNotification toastNotification)
        {
            try
            {
                ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
            }
            catch (Exception)
            {
                var dialog = new MessageDialog("ToastNotification_Error".GetLocalized());
                await dialog.ShowAsync();
            }
        }

        protected override async Task HandleInternalAsync(ToastNotificationActivatedEventArgs args)
        {
            //// TODO WTS: Handle activation from toast notification
            //// More details at https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/send-local-toast

            await Task.CompletedTask;
        }
    }
}