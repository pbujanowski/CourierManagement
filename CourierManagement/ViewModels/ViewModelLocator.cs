using System;

using CourierManagement.Services;
using CourierManagement.Views;

using GalaSoft.MvvmLight.Ioc;

namespace CourierManagement.ViewModels
{
    /// <summary>
    /// Lokalizator modelów widoku
    /// </summary>
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        /// <summary>
        /// Pole instancji lokalizatora modelu widoku
        /// </summary>
        private static ViewModelLocator _current;
        /// <summary>
        /// Właściwość instancji lokalizatora modelu widoku
        /// </summary>
        public static ViewModelLocator Current => _current ?? (_current = new ViewModelLocator());
        /// <summary>
        /// Konstruktor lokalizatora modelu widoku
        /// </summary>
        private ViewModelLocator()
        {
            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<MainViewModel, MainPage>();
            Register<CouriersViewModel, CouriersPage>();
            Register<SettingsViewModel, SettingsPage>();
        }

        public SettingsViewModel SettingsViewModel => SimpleIoc.Default.GetInstance<SettingsViewModel>();

        public CouriersViewModel CouriersViewModel => SimpleIoc.Default.GetInstance<CouriersViewModel>();

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();

        public ShellViewModel ShellViewModel => SimpleIoc.Default.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => SimpleIoc.Default.GetInstance<NavigationServiceEx>();
        /// <summary>
        /// Metoda rejestrująca modele widoku wraz z widokami
        /// </summary>
        /// <typeparam name="VM"></typeparam>
        /// <typeparam name="V"></typeparam>
        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
