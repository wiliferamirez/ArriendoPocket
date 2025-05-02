using ArriendoPocket.Areas.Identity.Pages;
using ArriendoPocket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArriendoPocket.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Arrendatario> signInManager;
        private readonly UserManager<Arrendatario> userManager;

        public AccountController(SignInManager<Arrendatario> signInManager, UserManager<Arrendatario> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Correo);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(
                        user.UserName, model.Contrasena, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Correo o contraseña incorrecta");
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Arrendatario arrendatario = new Arrendatario
                {
                    CedulaArrendatario = model.CedulaArrendatario,
                    NombreArrendatario = model.NombreArrendatario,
                    ApellidoArrendatario = model.ApellidoArrendatario,
                    UserName = model.NombreArrendatario + model.ApellidoArrendatario, 
                    CorreoArrendatario = model.CorreoArrendatario,
                    Email = model.CorreoArrendatario,
                    TelefonoArrendatario = model.TelefonoArrendatario,
                    FechaNacimientoArrendatario = model.FechaNacimientoArrendatario
                };
                var result = await userManager.CreateAsync(arrendatario, model.Contrasena);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
