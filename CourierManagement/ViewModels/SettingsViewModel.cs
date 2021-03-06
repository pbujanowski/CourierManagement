﻿using CourierManagement.Helpers;
using CourierManagement.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace CourierManagement.ViewModels
{
    // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
    /// <summary>
    /// Model widoku ustawień aplikacji
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        /// <summary>
        /// Pole motywu aplikacji
        /// </summary>
        private ElementTheme elementTheme = ThemeSelectorService.Theme;

        /// <summary>
        /// Właściwość motywu aplikacji
        /// </summary>
        public ElementTheme ElementTheme
        {
            get { return elementTheme; }

            set { Set(ref elementTheme, value); }
        }

        /// <summary>
        /// Pole z opisem wersji aplikacji
        /// </summary>
        private string versionDescription;

        /// <summary>
        /// Właściwość z opisem wersji aplikacji
        /// </summary>
        public string VersionDescription
        {
            get { return versionDescription; }

            set { Set(ref versionDescription, value); }
        }

        /// <summary>
        /// Pole komendy zmiany motywu
        /// </summary>
        private ICommand switchThemeCommand;

        /// <summary>
        /// Właściwość komendy zmiany motywu
        /// </summary>
        public ICommand SwitchThemeCommand
        {
            get
            {
                return switchThemeCommand ?? (switchThemeCommand = new RelayCommand<ElementTheme>(
                        async (param) =>
                        {
                            ElementTheme = param;
                            await ThemeSelectorService.SetThemeAsync(param).ConfigureAwait(false);
                        }));
            }
        }

        /// <summary>
        /// Konstruktor modelu widoku ustawień
        /// </summary>
        public SettingsViewModel()
        {
        }

        public void Initialize()
        {
            VersionDescription = GetVersionDescription();
        }

        /// <summary>
        /// Metoda zwracająca opis wersji aplikacji
        /// </summary>
        /// <returns></returns>
        private string GetVersionDescription()
        {
            var appName = "AppDisplayName".GetLocalized();
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}