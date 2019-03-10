using CourierManagement.Core.Models;
using CourierManagement.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Core;

namespace CourierManagement.ViewModels
{
    public class CourierViewModel : ViewModelBase
    {
        private Courier _courier;
        private ViewLifetimeControl _viewLifetimeControl;
        public void Initialize(ViewLifetimeControl viewLifetimeControl)
        {
            _viewLifetimeControl = viewLifetimeControl;
            _viewLifetimeControl.Released += OnViewLifeTimeControlReleased;
        }
        private async void OnViewLifeTimeControlReleased(object sender, EventArgs e)
        {
            _viewLifetimeControl.Released -= OnViewLifeTimeControlReleased;
            await WindowManagerService.Current.MainDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                WindowManagerService.Current.SecondaryViews.Remove(_viewLifetimeControl);
            });
                
        }

        public string FirstName
        {
            get { return _courier.FirstName; }
            set
            {
                _courier.FirstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get { return _courier.LastName; }
            set
            {
                _courier.LastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        public CourierViewModel()
        {
            _courier = new Courier();
            AcceptCommand = new RelayCommand(AcceptExecute);
        }

        public ICommand AcceptCommand { get; set; }
        private async void AcceptExecute()
        {
            await Task.CompletedTask;
        }
    }
}
