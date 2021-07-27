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
namespace BreedingLogg.Pages.EjemplaresMachos
{
    public class IndexModel : PageModel
    {
        private readonly BreedingLogg.Datos.ContextoBD _context;

        public IndexModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }

        public IList<EjemplarMacho> EjemplarMacho { get;set; }

        public async Task OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                Response.Redirect("/Presentación");
            }

            var idvalidacion = HttpContext.Session.GetInt32("idcriador");
            var idvalidacion2 = HttpContext.Session.GetString("nivel");

            if (idvalidacion2 == "Criador")
            {
                EjemplarMacho = await _context.EjemplaresMachos.Where(p => p.StatusEjemplarMacho == "Enable" && p.CriadorId == idvalidacion)
                .Include(e => e.Ciudad)
                .Include(e => e.Criador)
                .Include(e => e.Estado).ToListAsync();
            }
            else
            {
                EjemplarMacho = await _context.EjemplaresMachos.Where(p => p.StatusEjemplarMacho == "Enable")
                .Include(e => e.Ciudad)
                .Include(e => e.Criador)
                .Include(e => e.Estado).ToListAsync();
            }
            
        }
    }
}
