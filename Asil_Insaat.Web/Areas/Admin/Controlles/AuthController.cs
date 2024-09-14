using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asil_Insaat.Web.Areas.Admin.Controlles
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Giris()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Giris(UserGirisViewModel userGirisViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userGirisViewModel.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userGirisViewModel.Password, userGirisViewModel.BeniHatirla, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Girdiğiniz Bilgiler Hatalıdır.");
                        return View();
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Girdiğiniz Bilgiler Hatalıdır.");
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
       
        [Authorize]
        [HttpGet]

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}
