using CourierManagement.Core.Data;
using CourierManagement.Services;
using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace CourierManagement
{
    public sealed partial class App : Application
    {
        private readonly Lazy<ActivationService> activationService;

        private ActivationService ActivationService
        {
            get { return activationService.Value; }
        }

        private async void InitializeDatabase()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                await dbContext.Database.EnsureCreatedAsync().ConfigureAwait(false);
            }
        }

        public App()
        {
            InitializeComponent();
            InitializeDatabase();
            // Deferred execution until used. Check https://msdn.microsoft.com/library/dd642331(v=vs.110).aspx for further info on Lazy<T> class.
            activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args).ConfigureAwait(false);
            }
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args).ConfigureAwait(false);
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(ViewModels.MainViewModel), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }
    }
}
