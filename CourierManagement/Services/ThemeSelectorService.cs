using CourierManagement.Helpers;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace CourierManagement.Services
{
    /// <summary>
    /// Usługa wyboru motywu aplikacji
    /// </summary>
    public static class ThemeSelectorService
    {
        private const string SettingsKey = "AppBackgroundRequestedTheme";

        public static ElementTheme Theme { get; set; }

        /// <summary>
        /// Asynchroniczne statyczne zadanie inicjalizujące motyw na podstawie ustawień aplikacji
        /// </summary>
        /// <returns></returns>
        public static async Task InitializeAsync()
        {
            Theme = await LoadThemeFromSettingsAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchroniczne statycznie zadanie ustawiające motyw aplikacji
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public static async Task SetThemeAsync(ElementTheme theme)
        {
            Theme = theme;

            await SetRequestedThemeAsync().ConfigureAwait(false);
            await SaveThemeInSettingsAsync(Theme).ConfigureAwait(false);
        }

        public static async Task SetRequestedThemeAsync()
        {
            foreach (var view in CoreApplication.Views)
            {
                await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    if (Window.Current.Content is FrameworkElement frameworkElement)
                    {
                        frameworkElement.RequestedTheme = Theme;
                    }
                });
            }
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie wczytujące motyw z ustawień aplikacji
        /// </summary>
        /// <returns></returns>
        private static async Task<ElementTheme> LoadThemeFromSettingsAsync()
        {
            ElementTheme cacheTheme = ElementTheme.Default;
            string themeName = await ApplicationData.Current.LocalSettings.ReadAsync<string>(SettingsKey).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(themeName))
            {
                Enum.TryParse(themeName, out cacheTheme);
            }

            return cacheTheme;
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie zapisujące motyw w ustawieniach aplikacji
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        private static async Task SaveThemeInSettingsAsync(ElementTheme theme)
        {
            await ApplicationData.Current.LocalSettings.SaveAsync(SettingsKey, theme.ToString()).ConfigureAwait(false);
        }
    }
}