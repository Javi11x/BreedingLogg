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


namespace BreedingLogg.Pages.EjemplaresHembras
{
    public class IndexModel : PageModel
    {

        

        private readonly BreedingLogg.Datos.ContextoBD _context;

        public IndexModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }

        public IList<EjemplarHembra> EjemplarHembra { get; set; }

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
                EjemplarHembra = await _context.EjemplarHembras.Where(p => p.StatusEjemplarHembra == "Enable" && p.CriadorId == idvalidacion)
                .Include(e => e.Ciudad)
                .Include(e => e.Criador)
                .Include(e => e.Estado).ToListAsync();
            }
            else
            {
                EjemplarHembra = await _context.EjemplarHembras.Where(p => p.StatusEjemplarHembra == "Enable")
                .Include(e => e.Ciudad)
                .Include(e => e.Criador)
                .Include(e => e.Estado).ToListAsync();
            }

            //Criador = await _context.Criadores.Where(p => p.StatusCriador == "Enable").Include(p => p.EjemplarHembras).ToListAsync();
        }
    }
}

//EjemplarHembra = await _context.EjemplarHembras.Where(p => p.StatusEjemplarHembra == "Enable" && p.CriadorId == 9)
               //.Include(e => e.Ciudad)
               //.Include(e => e.Criador)
               //.Include(e => e.Estado).ToListAsync();