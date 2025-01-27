using frontend.Models;
using frontend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Controllers
{
    public class EquiposController : Controller
    {
        private readonly IEquiposService _equiposService;

        public EquiposController(IEquiposService equiposService)
        {
            _equiposService = equiposService;
        }

        // Acción para mostrar la lista de equipos
        public async Task<IActionResult> Index()
        {
            var equipos = await _equiposService.GetAllEquiposAsync();
            return View(equipos);
        }

        // Acción para mostrar los detalles de un equipo
        public async Task<IActionResult> Details(int id)
        {
            var equipo = await _equiposService.GetEquipoByIdAsync(id);
            if (equipo == null) return NotFound();
            return View(equipo);
        }

        // Mostrar la vista de creación
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Procesar la creación de un equipo
        [HttpPost]
        public async Task<IActionResult> Create(Equipos equipo)
        {
            if (!ModelState.IsValid)
            {
                return View(equipo); // Si hay errores, volver a mostrar el formulario
            }

            await _equiposService.AddEquipoAsync(equipo);
            return RedirectToAction(nameof(Index));
        }

        // Mostrar la vista de edición
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var equipo = await _equiposService.GetEquipoByIdAsync(id);
            if (equipo == null) return NotFound();
            return View(equipo);
        }

        // Procesar la edición de un equipo
        [HttpPost]
        public async Task<IActionResult> Edit(Equipos equipo)
        {
            if (!ModelState.IsValid)
            {
                return View(equipo); // Si hay errores, volver a mostrar el formulario
            }

            await _equiposService.UpdateEquipoAsync(equipo.Id, equipo);
            return RedirectToAction(nameof(Index));
        }

        // Confirmar eliminación de un equipo
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _equiposService.DeleteEquipoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
