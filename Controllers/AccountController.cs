using EnterpriseIMS.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseIMS.Controllers
{
    public class AccountController : Controller
    {

        /// <summary>
        /// This controller will display the cshtml
        /// that will supply the all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        public IActionResult UserList()
        {
            return View();
        }


        /// <summary>
        /// simple view for Login
        /// </summary>
        /// <returns>Return Login View</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns>Redirect to  homepage if success else same login page</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginVM loginVM)
        {
            return View();
        }
    }
}
