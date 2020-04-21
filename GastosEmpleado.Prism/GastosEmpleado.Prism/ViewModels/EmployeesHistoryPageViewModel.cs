using GastosEmpleado.Common.Models;
using GastosEmpleado.Common.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Linq;

namespace GastosEmpleado.Prism.ViewModels
{
    public class EmployeesHistoryPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private EmployeesResponse _Employees;
        private List<TripItemViewModel> _details;
        private DelegateCommand _checkDocumentCommand;
        private bool _isRunning;

        public EmployeesHistoryPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Employees History";
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public List<TripItemViewModel> Details
        {
            get => _details;
            set => SetProperty(ref _details, value);
        }


        public EmployeesResponse Employees
        {
            get => _Employees;
            set => SetProperty(ref _Employees, value);
        }
        public string Document { get; set; }

        public DelegateCommand CheckDocumentCommand => _checkDocumentCommand ?? (_checkDocumentCommand = new DelegateCommand(CheckDocumentAsync));

        private async void CheckDocumentAsync()
        {
            if (string.IsNullOrEmpty(Document))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a Document.",
                    "Accept");
                return;
            }

            IsRunning = true;
            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetEmployeesAsync(Document, url, "api", "/GastosEmpleado");
            IsRunning = false;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            Employees = (EmployeesResponse)response.Result;
            Details = Employees.Trips.Select(t=> new TripItemViewModel(_navigationService)
            {
                EndDate = t.EndDate,
                Id = t.Id,
                Remarks = t.Remarks,
                Source = t.Source,
                StartDate = t.StartDate,
                Target = t.Target,
                TripDetails = t.TripDetails,
                User = t.User


            }).ToList();
        }
    }
}
