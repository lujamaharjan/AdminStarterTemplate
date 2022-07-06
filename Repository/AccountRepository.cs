using EnterpriseIMS.Models.DbContext;
using EnterpriseIMS.Models.DomainModels;
using EnterpriseIMS.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseIMS.Repository
{
    public class AccountRepository:IAccountRepository
    {
        private EnterpriseImsDbContext _db;

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        private RoleManager<IdentityRole> _roleManager;
        private IConfiguration _configuration;

        public AccountRepository(
            EnterpriseImsDbContext db,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration
       
            )
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public List<IdentityRole> GetAllRoles()
        {
            return _db.Roles.ToList();
        }


        public async Task<IdentityResult> CreateUserAsync(AddUserVM userViewModel)
        {
            var user = new ApplicationUser()
            {
                Email = userViewModel.Email,
                UserName = userViewModel.Email,
                FirstName = userViewModel.FirstName,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                PhoneNumber = userViewModel.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, userViewModel.Password);

            switch (userViewModel.RoleId)
            {
                case 1:
                    await _userManager.AddToRoleAsync(user, "Admin");
                    break;
                case 2:
                    await _userManager.AddToRoleAsync(user, "RO");
                    break;
                case 3:
                    await _userManager.AddToRoleAsync(user, "Vendor");
                    break;
                case 4:
                    await _userManager.AddToRoleAsync(user, "Finance");
                    break;
                case 5:
                    await _userManager.AddToRoleAsync(user, "ISP Team");
                    break;
                case 6:
                    await _userManager.AddToRoleAsync(user, "Procrument");
                    break;
                case 7:
                    await _userManager.AddToRoleAsync(user, "Store");
                    break;
                default:
                    break;
            }
            return result;
        }

        public List<ApplicationUser> GetAllUser()
        {
            return _db.Users.ToList();
        }

     


        public async Task<SignInResult> Login(LoginVM loginVM)
        {
            return await _signInManager.PasswordSignInAsync(loginVM.Username, loginVM.Password, loginVM.RememberMe, false);
        }


        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }


        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _db.Users.SingleOrDefaultAsync(m => m.Email == email);
        }


        public async Task GenerateForgotPasswordTokenAsync(ApplicationUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPasswordEmail(user, token);
            }
        }


        private async Task SendForgotPasswordEmail(ApplicationUser user, string token)
        {
            //string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            //string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;
            //EmailOptions options = new EmailOptions()
            //{
            //    ToEmails = new List<string>() { user.Email },
            //    PlaceHolders = new List<KeyValuePair<string, string>>()
            //    {
            //        new KeyValuePair<string, string>("{{FirstName}}", user.FirstName),
            //        new KeyValuePair<string, string>("{{Link}}",
            //            string.Format(appDomain + confirmationLink, user.Id, token))
            //    }

            //};
            //await _emailService.SendEmailForForgotPassword(options);
        }


        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordVM model)
        {
            return await _userManager.
                ResetPasswordAsync(await _userManager.FindByIdAsync(model.Id), model.Token, model.NewPassword);
        }


        public ApplicationUser GetSingleUser(string id)
        {
            return _db.Users.Include("Warehouse").SingleOrDefault(m => m.Id == id);
        }

        public async Task<string> GetUserRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            return roles[0];
        }

        public async Task UpdateUser(UpdateUserVM updateUserVM)
        {
            var userInDb = await _userManager.FindByIdAsync(updateUserVM.Id);
            userInDb.FirstName = updateUserVM.FirstName;
            userInDb.MiddleName = updateUserVM.MiddleName;
            userInDb.LastName = updateUserVM.LastName;
            userInDb.Email = updateUserVM.Email;
            userInDb.PhoneNumber = updateUserVM.PhoneNumber;



            string newRole = _db.Roles.SingleOrDefault(m => m.Id == updateUserVM.RoleId.ToString()).Name;
            var currentRole = await _userManager.GetRolesAsync(userInDb);
            await _userManager.RemoveFromRoleAsync(userInDb, currentRole[0]);
            await _userManager.AddToRoleAsync(userInDb, newRole);
            await _db.SaveChangesAsync();
        }

        public void DeleteUser(string id)
        {
            var user = _db.Users.SingleOrDefault(m => m.Id == id);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordVM model, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }


    }
}
