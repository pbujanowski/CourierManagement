using System;
using System.Threading.Tasks;

using CourierManagement.Activation;

using Windows.ApplicationModel.Activation;
using Windows.UI.Notifications;

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
        public void ShowToastNotification(ToastNotification toastNotification)
        {
            try
            {
                ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
            }
            catch (Exception)
            {
                // TODO WTS: Adding ToastNotification can fail in rare conditions, please handle exceptions as appropriate to your scenario.
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
