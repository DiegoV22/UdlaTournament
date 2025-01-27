using frontend.Models;
using frontend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Controllers
{
    public class TorneosController : Controller
    {
        private readonly ITorneosService _torneosService;

        public TorneosController(ITorneosService torneosService)
        {
            _torneosService = torneosService;
        }

        // Acción para mostrar la lista de torneos
        public async Task<IActionResult> Index()
        {
            var torneos = await _torneosService.GetAllTorneosAsync();
            return View(torneos);
        }

        // Acción para mostrar los detalles de un torneo
        public async Task<IActionResult> Details(int id)
        {
            var torneo = await _torneosService.GetTorneoByIdAsync(id);
            if (torneo == null) return NotFound();
            return View(torneo);
        }

        // Mostrar la vista de creación
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Procesar la creación de un torneo
        [HttpPost]
        public async Task<IActionResult> Create(Torneos torneo)
        {
            if (!ModelState.IsValid)
            {
                return View(torneo); // Si hay errores, volver a mostrar el formulario
            }

            await _torneosService.AddTorneoAsync(torneo);
            return RedirectToAction(nameof(Index));
        }

        // Mostrar la vista de edición
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var torneo = await _torneosService.GetTorneoByIdAsync(id);
            if (torneo == null) return NotFound();
            return View(torneo);
        }

        // Procesar la edición de un torneo
        [HttpPost]
        public async Task<IActionResult> Edit(Torneos torneo)
        {
            if (!ModelState.IsValid)
            {
                return View(torneo); // Si hay errores, volver a mostrar el formulario
            }

            await _torneosService.UpdateTorneoAsync(torneo.Id, torneo);
            return RedirectToAction(nameof(Index));
        }

        // Confirmar eliminación de un torneo
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _torneosService.DeleteTorneoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
