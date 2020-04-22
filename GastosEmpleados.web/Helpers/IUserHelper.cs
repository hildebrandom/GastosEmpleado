using GastosEmpleados.web.Data.Entities;
using GastosEmpleados.web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;



namespace GastosEmpleados.web.Helpers
{
    public interface IUserHelper
    {
        Task<UserEntity> GetUserAsync(string email);
        Task<UserEntity> GetUserAsync(Guid userId);

        Task<IdentityResult> AddUserAsync(UserEntity user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserEntity user, string roleName);

        Task<bool> IsUserInRoleAsync(UserEntity user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task<SignInResult> ValidatePasswordAsync(UserEntity user, string password);

        Task LogoutAsync();

        Task<UserEntity> AddUserAsync(AddUserViewModel model, string path);

    }
}
