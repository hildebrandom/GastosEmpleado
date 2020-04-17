using GastosEmpleado.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GastosEmpleado.Prism.ViewModels
{
    public class EmployeesMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public EmployeesMasterDetailPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_airplanemode_active",
                    PageName = "HomePage",
                    Title = "New trip"
                },
                new Menu
                {
                    Icon = "ic_assignment",
                    PageName = "EmployeesHistoryPage",
                    Title = "See trip details"
                },
                
                new Menu
                {
                    Icon = "ic_edit",
                    PageName = "ModifyUserPage",
                    Title = "Modify User"
                },
                new Menu
                               
                {
                    Icon = "ic_how_to_reg",
                    PageName = "LoginPage",
                    Title = "Log in"
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }
    }
}

