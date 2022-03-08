using Assigment_Mvc.Data;
using Assigment_Mvc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Assigment_Mvc.Controllers
{
    public class AccountController : Controller
    {
        private MyIdentityDbContext db;
        private UserManager<Account> userManager;
        private SignInManager<Account, string> signInManager;

        // GET: Account
        public AccountController()
        {
            db = new MyIdentityDbContext();
            UserStore<Account> userStore = new UserStore<Account>(db);
            userManager = new UserManager<Account>(userStore);
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string Email, string PasswordHash, string PhoneNumber, string UserName, string IdentityCard)
        {

            Account account = new Account()
            {
                UserName = UserName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                IdentityCard = IdentityCard,
            };
            var result = await userManager.CreateAsync(account, PasswordHash);
            if (result.Succeeded)
            {
                return View("CreateAccountSuccess");
            }
            else
            {
                return View("CreateAccountFails");
            }

        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string UserName, string PasswordHash)
        {
            // sử dụng userManager để check thông tin đăng nhập.
            var account = await userManager.FindAsync(UserName, PasswordHash);
            if (account != null)
            {
                // đăng nhập  thành công thì dùng SignInManager để lưu lại thông tin vừa đăng nhập.
                signInManager = new SignInManager<Account, string>(userManager, Request.GetOwinContext().Authentication);
                await signInManager.SignInAsync(account, isPersistent: false, rememberBrowser: false);
                return View("CreateAccountSuccess");
            }
            else
            {
                return View("CreateAccountFails");
            }
        }
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Account/Login");
        }

        public ActionResult List()
        {
            return View();
        }

    }
}