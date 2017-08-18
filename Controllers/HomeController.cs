using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreauthtest.Infrastructure;
using coreauthtest.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OtpSharp;

namespace coreauthtest.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager){
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
            var user = new ApplicationUser{ UserName = "admin",  Email = "admin@lassi.ninja" };
            
            await this.userManager.CreateAsync(user, "password");

            return Json("OK");
        }
        
        [Authorize]
        public async Task<IActionResult> Enable()
        {
            string userName = User.Identity.Name;
            var user = await this.userManager.FindByIdAsync(userName);
            if(user.IsTotpEnabled)
                return Json("OTP already enabled");

            user.IsTotpEnabled = true;
            byte[] secret = KeyGeneration.GenerateRandomKey(20);
            user.ToptSecretKey = Base64Encoder.Encode(secret);
            string barcodeUrl = KeyUrl.GetTotpUrl(secret, userName);

            return Json(barcodeUrl);
        }
        

        [Authorize]
        public async Task<IActionResult> Logout(){
            await this.signInManager.SignOutAsync();
            return Json("OK");
        }

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
