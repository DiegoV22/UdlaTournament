using frontend.Models;
using frontend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly IJugadoresService _jugadoresService;

        public JugadoresController(IJugadoresService jugadoresService)
        {
            _jugadoresService = jugadoresService;
        }

        // Acción para mostrar la lista de jugadores
        public async Task<IActionResult> Index()
        {
            var jugadores = await _jugadoresService.GetAllJugadoresAsync();
            return View(jugadores);
        }

        // Acción para mostrar los detalles de un jugador
        public async Task<IActionResult> Details(int id)
        {
            var jugador = await _jugadoresService.GetJugadorByIdAsync(id);
            if (jugador == null) return NotFound();
            return View(jugador);
        }

        // Mostrar la vista de creación
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Procesar la creación del jugador
        [HttpPost]
        public async Task<IActionResult> Create(Jugadores jugador)
        {
            if (!ModelState.IsValid)
            {
                return View(jugador); // Si hay errores, volver a mostrar el formulario
            }

            await _jugadoresService.AddJugadorAsync(jugador);
            return RedirectToAction(nameof(Index));
        }

        // Mostrar la vista de edición
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var jugador = await _jugadoresService.GetJugadorByIdAsync(id);
            if (jugador == null) return NotFound();
            return View(jugador);
        }

        // Procesar la edición del jugador
        [HttpPost]
        public async Task<IActionResult> Edit(Jugadores jugador)
        {
            if (!ModelState.IsValid)
            {
                return View(jugador); // Si hay errores, volver a mostrar el formulario
            }

            await _jugadoresService.UpdateJugadorAsync(jugador.Id, jugador);
            return RedirectToAction(nameof(Index));
        }

        // Confirmar eliminación de un jugador
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _jugadoresService.DeleteJugadorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
