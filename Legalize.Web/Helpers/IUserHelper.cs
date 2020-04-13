using Legalize.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Helpers
{
    public interface IUserHelper
    {

        Task<UserEntity> GetUserByEmailAsync(String email);
        Task<IdentityResult> AddUserAsync(UserEntity user, string password);
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(UserEntity user, string roleName);
        Task<bool> IsUserInRoleAsync(UserEntity user, string roleName);
        Task GetUserAsync(string email);


        /*Task<string> GeneratePasswordResetTokenAsync(UserEntity user);

        Task<IdentityResult> ResetPasswordAsync(UserEntity user, string token, string password);

        Task<string> GenerateEmailConfirmationTokenAsync(UserEntity user);

        Task<IdentityResult> ConfirmEmailAsync(UserEntity user, string token);

        Task<IdentityResult> ChangePasswordAsync(UserEntity user, string oldPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(UserEntity user);

        Task<UserEntity> GetUserAsync(string email);

        Task<UserEntity> GetUserAsync(Guid userId);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task<SignInResult> ValidatePasswordAsync(UserEntity user, string password);

        Task LogoutAsync();

       Task<UserEntity> AddUserAsync(AddUserViewModel model, string path);*/
    }
}
