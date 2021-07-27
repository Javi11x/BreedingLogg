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
    public class DeleteModel : PageModel
    {
        private readonly BreedingLogg.Datos.ContextoBD _context;

        public DeleteModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }

        [BindProperty]
        public Cruce Cruce { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                Response.Redirect("/Presentación");
            }

            if (id == null)
            {
                return NotFound();
            }

            Cruce = await _context.Cruces
                .Include(c => c.Criador)
                .Include(c => c.EjemplarHembra)
                .Include(c => c.EjemplarMacho).FirstOrDefaultAsync(m => m.CruceId == id);

            if (Cruce == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cruce = await _context.Cruces.FindAsync(id);

            if (Cruce != null)
            {
                Cruce.StatusCruce = "Disabled";

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");

            
        }
    }
}
