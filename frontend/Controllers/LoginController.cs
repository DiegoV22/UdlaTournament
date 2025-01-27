using frontend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace frontend.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Gmail, string Contrasena)
        {
            var usuario = await _loginService.Login(Gmail, Contrasena);

            if (usuario != null)
            {
                TempData["Mensaje"] = "Inicio de sesión exitoso";
                // Redirige al Home/Index después de un inicio de sesión exitoso
                return RedirectToAction("Index", "Home");
            }

            TempData["Error"] = "Credenciales incorrectas.";
            return RedirectToAction(nameof(Index)); // Si las credenciales son inválidas, vuelve al Login
        }
    }
}