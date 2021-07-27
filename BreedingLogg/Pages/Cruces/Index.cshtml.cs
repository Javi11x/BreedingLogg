using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BreedingLogg.Datos;
using BreedingLogg.Modelos;
using Microsoft.AspNetCore.Http;
namespace BreedingLogg.Pages.Cruces
{
    public class IndexModel : PageModel
    {
        private readonly BreedingLogg.Datos.ContextoBD _context;

        public IndexModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }

        public IList<Cruce> Cruce { get;set; }

        public async Task OnGetAsync()
        {


            var idvalidacion = HttpContext.Session.GetInt32("idcriador");
            var idvalidacion2 = HttpContext.Session.GetString("nivel");

            if(idvalidacion2 == "Criador")
            {
                Cruce = await _context.Cruces.Where(p => p.CriadorId == idvalidacion && p.StatusCruce == "Enable")
                .Include(c => c.Criador)
                .Include(c => c.EjemplarHembra)
                .Include(c => c.EjemplarMacho).ToListAsync();
            }
            else
            {
                Cruce = await _context.Cruces.Where(p => p.StatusCruce == "Enable")
                .Include(c => c.Criador)
                .Include(c => c.EjemplarHembra)
                .Include(c => c.EjemplarMacho).ToListAsync();
            }
            
        }
    }
}
