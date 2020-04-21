using GastosEmpleado.Common.Enums;
using GastosEmpleados.web;
using GastosEmpleados.web.Data;
using GastosEmpleados.web.Data.Entities;
using GastosEmpleados.web.Helpers;
using Microsoft.EntityFrameworkCore;
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
            await CheckUserAsync("98648886", "Hildebrando", "Montoya", "hilderbrand2007@hotmail.com", "3005337420", "Calle Luna", UserType.Admin);
            await CheckEmployeesAsync();
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
            UserEntity user = await _userHelper.GetUserByEmailAsync(email);
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
                    UserType = userType
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

        private async Task CheckEmployeesAsync()

        {
            if (!_dataContext.Employees.Any())
            {
                UserEntity employees = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserType == UserType.Admin);
                int i = 0;

                foreach (UserEntity user in _dataContext.Users.Where(u => u.UserType == UserType.User))
                {
                    i++;
                    string document = "98648886";
                    AddEmployees(document, user, employees);
                    
                }

                await _dataContext.SaveChangesAsync();


            }
        }

        private void AddEmployees(string document, UserEntity user1, UserEntity employees)
        {
            _dataContext.Employees.Add(new EmployeesEntity
            {
                Document = document,
                User = employees,
                Trips = new List<TripsEntity>

                {
                    new TripsEntity

                    {
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMinutes(30),
                        Source = "Medellin",
                        Target = "Cartagena",
                        Remarks = "Visita Cliente Pacif Rubiales",
                        User = user1
                    },

                    new TripsEntity
                    {
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMinutes(30),
                        Source = "Medellin",
                        Target = "Bogota",
                        Remarks = "Visita cliente Ecopetrol",
                        User = user1
                    }
                }
            });
        }

        private class Photo
        {
            public string Firstname { get; set; }

            public string Lastname { get; set; }

            public string Image { get; set; }
        }
    }
}

