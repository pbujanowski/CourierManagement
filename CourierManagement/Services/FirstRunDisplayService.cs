using CourierManagement.Views;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Threading.Tasks;

namespace CourierManagement.Services
{
    /// <summary>
    /// Usługa dla okna dialogowego przy pierwszym uruchamianiu aplikacji
    /// </summary>
    public static class FirstRunDisplayService
    {
        private static bool shown;

        /// <summary>
        /// Asynchroniczna metoda pokazująca okno dialogowe przy pierwszym uruchomieniu
        /// </summary>
        /// <returns></returns>
        internal static async Task ShowIfAppropriateAsync()
        {
            if (SystemInformation.IsFirstRun && !shown)
            {
                shown = true;
                var dialog = new FirstRunDialog();
                await dialog.ShowAsync();
            }
        }
    }
}
