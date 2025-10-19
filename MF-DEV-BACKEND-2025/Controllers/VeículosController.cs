using MF_DEV_BACKEND_2025.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MF_DEV_BACKEND_2025.Controllers
{
    public class VeículosController : Controller
    {
        private readonly AppDbContext _context;
        public VeículosController(AppDbContext context)
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
        public async Task<IActionResult> Create(Veículo veículo)
        {
            if (ModelState.IsValid)
            {

                _context.Veículos.Add(veículo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            return View(veículo);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veículos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veículo veículo)
        {
            if (id != veículo.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Veículos.Update(veículo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
        
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veículos.FindAsync(id);

            if(dados == null)
                return NotFound();

            return View(dados);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veículos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veículos.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Veículos.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
