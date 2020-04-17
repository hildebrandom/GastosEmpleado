using Prism;
using Prism.Ioc;
using GastosEmpleado.Prism.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GastosEmpleado.Prism.Views;

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

            await NavigationService.NavigateAsync("/EmployeesMasterDetailPage/NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<EmployeesMasterDetailPage, EmployeesMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<EmployeeHistoryPage, EmployeesHistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
        }
    }
}
