using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.ViewModels
{
    /// <summary>
    /// Klasa-lokalizator, w której tworzy się właściwości (property) dla modeli widoku (view models) oraz rejestruje je - wymagane przez widoki
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Właściwość zwracająca instancję głównego modelu widoku
        /// </summary>
        public MainViewModel Main { get { return ServiceLocator.Current.GetInstance<MainViewModel>(); } }
        /// <summary>
        /// Statyczny konstruktor klasy, w którym NALEŻY(!) zarejestrować wszystkie modele widoku (view models)
        /// </summary>
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
        }
    }
}
