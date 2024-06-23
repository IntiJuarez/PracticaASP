using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaASP.Models;
using PracticaASP.Models.ViewModels;

namespace PracticaASP.Controllers
{
    public class ShoesController : Controller
    {
        private readonly PubContext _context;

        public ShoesController(PubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Shoes = _context.Shoes.Include(b => b.Brand);

            return View(await Shoes.ToListAsync());
        }

        
        public IActionResult Create()
        {
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name");

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShoesViewModel model)
        {

            //Validación para guardar
            if(ModelState.IsValid)
            {
                var shoes = new Shoes()
                {
                    Name = model.Name,
                    BrandId = model.BrandId
                };
                _context.Add(shoes);
                //Importante para guardar en la db
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", model.BrandId);

            return View();
        }

        //Get Eliminar Zapatillas
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shoes == null)
            {
                return NotFound();
            }

            var shoes = await _context.Shoes
                 //.Include(s => s.Brand)
                 .FirstOrDefaultAsync(m => m.ShoesId == id);
            if (shoes == null)
            {
                return NotFound();
            }

            return View(shoes);
        }


        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoes = await _context.Shoes.FindAsync(id);

            if(shoes == null)
            {
                return NotFound();
            }
            _context.Shoes.Remove(shoes);
            //Guardamos cambios en DB
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
