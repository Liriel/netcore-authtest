using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreauthtest.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace coreauthtest.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager){
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public async Task<IActionResult> Register()
        {
            var user = new IdentityUser { UserName = "admin",  Email = "admin@lassi.ninja" };
            await this.userManager.CreateAsync(user, "password");

            return Json("OK");
        }

        [Authorize]
        public async Task<IActionResult> Logout(){
            await this.signInManager.SignOutAsync();
            return Json("OK");
        }

        [Authorize]
        public IActionResult Get()
        {
            var q = from u in this.userManager.Users
                select new {
                    u.Id,
                    u.UserName,
                    u.Email
                };

            return Json(q.First());
        }

        public async Task<IActionResult> Login(string userName, string password){
            await this.signInManager.PasswordSignInAsync(userName, password, false, false);
            return Json("OK");
        }
    }
}
