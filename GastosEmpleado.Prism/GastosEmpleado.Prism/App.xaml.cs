using Prism;
using Prism.Ioc;
using GastosEmpleado.Prism.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GastosEmpleado.Prism.Views;
using GastosEmpleado.Common.Services;
using Syncfusion.Licensing;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GastosEmpleado.Prism
{
    public partial class App
    {
        
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            SyncfusionLicenseProvider.RegisterLicense("MjQyNzMyQDMxMzgyZTMxMmUzMFNsU2R5emRFMmVMdUFYTDhCU0NyUWJrMldsZUxpN1g2QjhrakVPMk9xQWs9");
            await NavigationService.NavigateAsync("/EmployeesMasterDetailPage/NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IGeolocatorService, GeolocatorService>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<EmployeesMasterDetailPage, EmployeesMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<EmployeesHistoryPage, EmployeesHistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
        }
    }
}
