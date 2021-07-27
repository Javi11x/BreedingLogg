using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BreedingLogg.Datos;
using BreedingLogg.Modelos;

namespace BreedingLogg.Pages.EjemplaresHembras
{
    public class DetailsModel : PageModel
    {
        private readonly BreedingLogg.Datos.ContextoBD _context;

        public DetailsModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }

        public EjemplarHembra EjemplarHembra { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EjemplarHembra = await _context.EjemplarHembras
                .Include(e => e.Ciudad)
                .Include(e => e.Criador)
                .Include(e => e.Estado).FirstOrDefaultAsync(m => m.EjemplarHembraId == id);

            if (EjemplarHembra == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
