using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BreedingLogg.Datos;
using BreedingLogg.Modelos;

namespace BreedingLogg.Pages.Criadores
{
    public class DetailsModel : PageModel
    {
        private readonly BreedingLogg.Datos.ContextoBD _context;

        public DetailsModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }

        public Criador Criador { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Criador = await _context.Criadores.FirstOrDefaultAsync(m => m.CriadorId == id);

            if (Criador == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
