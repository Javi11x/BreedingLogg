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
namespace BreedingLogg.Pages.Criadores
{
    public class IndexModel : PageModel
    {
        private readonly BreedingLogg.Datos.ContextoBD _context;

        public IndexModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }

        public IList<Criador> Criador { get;set; }

        public async Task OnGetAsync(int? id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                Response.Redirect("/Presentación");
            }

            Criador = await _context.Criadores.Where(p => p.StatusCriador == "Enable")
                .Include(p => p.EjemplarHembras)
                .Include(p => p.EjemplarMachos)
                .Include(p => p.Cruces).ToListAsync();
        }
    }
}
//ToListAsync()