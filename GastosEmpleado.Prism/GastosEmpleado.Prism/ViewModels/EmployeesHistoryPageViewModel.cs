using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GastosEmpleado.Prism.ViewModels
{
    public class EmployeesHistoryPageViewModel : ViewModelBase
    {
        public EmployeesHistoryPageViewModel(INavigationService navigationService)
            : base (navigationService)
        {
            Title = "Trip details";
        }
    }
}
