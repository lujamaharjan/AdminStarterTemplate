using EnterpriseIMS.Models.DomainModels;
using EnterpriseIMS.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnterpriseIMS.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(AddUserVM userViewModel);
        List<ApplicationUser> GetAllUser();
        Task<SignInResult> Login(LoginVM loginVM);
        Task SignOutAsync();
        Task GenerateForgotPasswordTokenAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordVM model);
        ApplicationUser GetSingleUser(string id);
        Task UpdateUser(UpdateUserVM updateUserVM);

        void DeleteUser(string id);
        Task<string> GetUserRole(string id);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordVM model, string id);

    }
}
