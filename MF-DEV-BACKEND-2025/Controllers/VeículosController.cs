using MF_DEV_BACKEND_2025.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MF_DEV_BACKEND_2025.Controllers
{
    public class VeículosController : Controller
    {
        private readonly AppDbContext _context;
        public VeículosController (AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veículos.ToListAsync();

            return View(dados);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create (Veículo veículo) 
        {
            if (ModelState.IsValid) 
            {

                _context.Veículos.Add(veículo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            return View(veículo);
        }
  
    }
}
