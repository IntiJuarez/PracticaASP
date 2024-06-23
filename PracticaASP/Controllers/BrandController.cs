using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaASP.Models;

namespace PracticaASP.Controllers
{
    public class BrandController : Controller
    {

        private readonly PubContext _context;

        //Constructor
        public BrandController( PubContext context)
        {
            _context = context;
        }

        //Trae una lista de objetos tipo Brands(Marcas)
        public async Task<IActionResult> Index()
         =>View(await _context.Brands.ToListAsync());


        
    }
}
