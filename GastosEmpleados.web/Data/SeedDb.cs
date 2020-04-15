using GastosEmpleado.Common.Enums;
using GastosEmpleados.web;
using GastosEmpleados.web.Data;
using GastosEmpleados.web.Data.Entities;
using GastosEmpleados.web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GastosEmpleado.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext dataContext,
                      IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoleAsync();
            var Admin = await CheckUserAsync("98648886", "Hildebrando", "Montoya", "hilderbrand2007@hotmail.com", "3005337420", "Calle Luna", UserType.Admin);
            var user1 = await CheckUserAsync("1018237330", "Juan Jose", "Montoya", "hilderbrand2007@hotmail.com", "3005337420", "Calle Luna", UserType.User);
            var user2 = await CheckUserAsync("43927046", "Juan Jose", "Montoya", "hilderbrand2007@hotmail.com", "3005337420", "Calle Luna", UserType.User);
            await CheckEmployeesAsync(user1, user2);
        }

        private async Task<UserEntity> CheckUserAsync(
           string document,
           string firstName,
           string lastName,
           string email,
           string phone,
           string address,
           UserType userType)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    User = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRoleAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckEmployeesAsync(
            UserEntity user1,
            UserEntity user2)

        {
            if (!_dataContext.Employees.Any())
            {

                _dataContext.Employees.Add(new EmployeesEntity
                {
                    Document = "1018237330",
                    
                });

                await _dataContext.SaveChangesAsync();


            }
        }
    }
}

