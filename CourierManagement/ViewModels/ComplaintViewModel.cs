using CourierManagement.Core.Models;
using CourierManagement.DataAccess.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace CourierManagement.ViewModels
{
    public class ComplaintViewModel : ViewModelBase, IViewModel
    {
        private readonly Complaint complaint;

        public Delivery ComplainedDelivery
        {
            get { return complaint.ComplainedDelivery; }
            set
            {
                complaint.ComplainedDelivery = value;
                RaisePropertyChanged(nameof(ComplainedDelivery));
            }
        }

        public string Description
        {
            get { return complaint.Description; }
            set
            {
                complaint.Description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

        public DateTime SubmissionDate
        {
            get { return complaint.SubmissionDate; }
            set
            {
                complaint.SubmissionDate = value;
                RaisePropertyChanged(nameof(SubmissionDate));
            }
        }

        public ICommand AcceptCommand { get; set; }

        private async void AcceptExecute()
        {
            await DataService.AddToDatabaseAsync(complaint).ConfigureAwait(false);
        }

        public IDataService DataService { get; set; }

        public ComplaintViewModel()
        {
            complaint = new Complaint();
            DataService = new ComplaintService();
            AcceptCommand = new RelayCommand(AcceptExecute);
        }
    }
}
