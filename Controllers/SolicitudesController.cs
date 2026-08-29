using evaluacion20262.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace evaluacion20262.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly AppDbContext _context;

        public SolicitudesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(SolicitudServicio solicitud)
        {
            if (ModelState.IsValid)
            {
                _context.Solicitudes.Add(solicitud);
                await _context.SaveChangesAsync();

                return RedirectToAction("Crear");
            }

            return View(solicitud);
        }

        public async Task<IActionResult> Index()
        {
            var solicitudes = await _context.Solicitudes
                .OrderByDescending(s => s.FechaRegistro)
                .ToListAsync();

            return View(solicitudes);
        }
    }
}