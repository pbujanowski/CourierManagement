using CourierManagement.Views;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Threading.Tasks;

namespace CourierManagement.Services
{
    // For instructions on testing this service see https://github.com/Microsoft/WindowsTemplateStudio/tree/master/docs/features/whats-new-prompt.md
    /// <summary>
    /// Usługa dla okna dialogowego po aktualizacji aplikacji
    /// </summary>
    public static class WhatsNewDisplayService
    {
        private static bool shown;

        /// <summary>
        /// Asynchroniczne statyczne zadanie wyświetlające okno dialogowe po aktualizacji aplikacji
        /// </summary>
        /// <returns></returns>
        internal static async Task ShowIfAppropriateAsync()
        {
            if (SystemInformation.IsAppUpdated && !shown)
            {
                shown = true;
                var dialog = new WhatsNewDialog();
                await dialog.ShowAsync();
            }
        }
    }
}