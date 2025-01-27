using frontend.Models;
using frontend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuariosService _usuariosService;

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        // Acción para mostrar la lista de usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuariosService.GetAllUsuariosAsync();
            return View(usuarios);
        }

        // Acción para mostrar los detalles de un usuario
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _usuariosService.GetUsuarioByIdAsync(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        // Mostrar la vista de creación
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Procesar la creación del usuario
        [HttpPost]
        public async Task<IActionResult> Create(Usuarios usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario); // Si hay errores, volver a mostrar el formulario
            }

            await _usuariosService.AddUsuarioAsync(usuario);
            return RedirectToAction(nameof(Index));
        }

        // Mostrar la vista de edición
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _usuariosService.GetUsuarioByIdAsync(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        // Procesar la edición del usuario
        [HttpPost]
        public async Task<IActionResult> Edit(Usuarios usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario); // Si hay errores, volver a mostrar el formulario
            }

            await _usuariosService.UpdateUsuarioAsync(usuario.Id, usuario);
            return RedirectToAction(nameof(Index));
        }

        // Confirmar eliminación de un usuario
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _usuariosService.DeleteUsuarioAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
