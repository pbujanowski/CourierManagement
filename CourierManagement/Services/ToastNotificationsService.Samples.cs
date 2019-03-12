using Microsoft.Toolkit.Uwp.Notifications;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace CourierManagement.Services
{
    internal partial class ToastNotificationsService
    {
        /// <summary>
        /// Metoda wyświetlająca przykładowe powiadomienie w systemie Windows
        /// </summary>
        public async Task ShowToastNotificationSampleAsync()
        {
            // Create the toast content
            var content = new ToastContent()
            {
                // More about the Launch property at https://docs.microsoft.com/dotnet/api/microsoft.toolkit.uwp.notifications.toastcontent
                Launch = "ToastContentActivationParams",

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "Przykładowe powiadomienie"
                            },

                            new AdaptiveText()
                            {
                                 Text = "Naciśnij przycisk OK, aby zamknąć powiadomienie."
                            }
                        }
                    }
                },

                Actions = new ToastActionsCustom()
                {
                    Buttons =
                    {
                        // More about Toast Buttons at https://docs.microsoft.com/dotnet/api/microsoft.toolkit.uwp.notifications.toastbutton
                        new ToastButton("OK", "ToastButtonActivationArguments")
                        {
                            ActivationType = ToastActivationType.Foreground
                        },

                        new ToastButtonDismiss("Cancel")
                    }
                }
            };

            // Add the content to the toast
            var toast = new ToastNotification(content.GetXml())
            {
                // TODO WTS: Set a unique identifier for this notification within the notification group. (optional)
                // More details at https://docs.microsoft.com/uwp/api/windows.ui.notifications.toastnotification.tag
                Tag = "ToastTag"
            };

            // And show the toast
            await ShowToastNotificationAsync(toast).ConfigureAwait(false);
        }
    }
}
