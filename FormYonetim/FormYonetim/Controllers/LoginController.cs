using DataAccess;
using Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FormYonetim.Controllers
{
    public class LoginController : Controller
    {
        

        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        [Route("LoginControl")]
        public async Task<IActionResult> LoginControl(string username, string password)
        {
            Repository repository = new Repository();
            Users user =  repository.Control(username,password);
            
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,username)
                };
                var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(useridentity), authProperties);
                return RedirectToAction("Index", "Form");
            }

            TempData["error"] = "Kullanıcı adı veya şifre hatalı!";
            return RedirectToAction("LoginPage");
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("LoginPage");
        }

    }
}
